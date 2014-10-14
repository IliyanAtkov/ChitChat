<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to login the user:
*/

if (isset($_POST['id'])) {
	//Assing variables sent from the program
	$id = 		mysql_real_escape_string($_POST['id']);

	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);

	if ($conn) {
		$select_db = mysql_select_db(DB_NAME, $conn);

		if ($select_db) {
			$sql  = "SELECT U.id, U.name, U.onlineStance 
					FROM users U, contacts C  
					WHERE
					CASE
					
					WHEN C.user_id = '{$id}'
					THEN U.id = C.friend_id
					WHEN C.friend_id = '{$id}'
					THEN U.id = C.user_id
					
					END";
		
			$result = mysql_query($sql, $conn);
			if($result) // If executed successfuly
			{
				if (mysql_num_rows($result) >= 1) 
				{	
					echo "true";
					while($info = mysql_fetch_array($result))
					{	
						echo "<new>";
						echo "<sep>id={$info['id']}";
						echo "<sep>name={$info['name']}";
						echo "<sep>onlineStance={$info['onlineStance']}";
					}
				}
				else 
				{
					echo "false";
				}
			}
			else
			{
				echo "Not executed properly";
			}
		}
		else {
			die("Cannot select database!<br />" . mysql_error());
		}
	}
	else {
		die("Cannot connect to database!<br />" . mysql_error());
	}
}
else {
	echo "<h1>Sorry, you have no place here :)</h1>";
}