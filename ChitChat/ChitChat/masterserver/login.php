<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to login the user:
*/

if (isset($_POST['username'])) {
	//Assing variables sent from the program
	$username = 		$_POST['username'];
	$password = 		$_POST['password'];

	//Some protection from SQL injection
	$username = stripslashes($username);
	$username = mysql_real_escape_string($username);
	$password = stripslashes($password);
	$password = mysql_real_escape_string($password);

	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);

	if ($conn) {
		$select_db = mysql_select_db(DB_NAME, $conn);

		if ($select_db) {
			$sql  = "SELECT id FROM users WHERE username = '{$username}' AND password = '{$password}'";
		
			$result = mysql_query($sql, $conn);
			
			if($result) // If executed successfuly
			{
				if (mysql_num_rows($result) == 1) 
				{	
					echo "true";
				}
				else 
				{
					echo "false";
				}
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