<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to register a user:
*/

if (isset($_POST['data'])) {
	//Assing variables sent from the program
	$whatToUpdate = 	$_POST['whatToUpdate'];
	$data = 			$_POST['data'];
	$id = 				$_POST['userID'];

	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);

	if ($conn) {
		$select_db = mysql_select_db(DB_NAME, $conn);

		if ($select_db) {

			$sql  = "UPDATE users SET `{$whatToUpdate}`='$data' WHERE id = {$id}";
		
			$result = mysql_query($sql, $conn);
			
			if($result)
			{
				echo "true";
			}
			else
			{
				echo "false";
				mysql_error();
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