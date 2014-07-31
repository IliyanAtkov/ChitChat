<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to register a user:
*/

if (isset($_POST['username'])) 
{
	//Assing variables sent from the program
	$username =	mysql_prep($_POST['firstname']);
	$password = mysql_prep($_POST['password']);
	$email 	  = mysql_prep($_POST['email']);
	$ip		  = mysql_prep($_POST['ip']);
	$sex 	  = mysql_prep($_POST['sex']);

	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);

	if ($conn) 
	{
		$select_db = mysql_select_db(DB_NAME, $conn);

		if ($select_db) 
		{
				$sql  = "SELECT id FROM users WHERE email = '{$email}'"
				$result = mysql_query($sql, $conn);
				if(mysql_num_rows($result) >= 1) 
				{
					die("Email already registered");
				}
				
				$sql  = "SELECT id FROM users WHERE username = '{$username}'"
				$result = mysql_query($sql, $conn);
				if(mysql_num_rows($result) >= 1) 
				{
					die("Username already exists");
				}
			
				$sql  = "INSERT INTO users (`username`, `password`, `email`, `joinDate`, `ip`, `info`, `city`, `nation`, `phone`, `sex`, `name`, `isDonator`, `onlineStance`) 
						VALUES ('{$username}', '{$password}', '{$email}', now(), '{$ip}', NULL, NULL, NULL, NULL, '{$sex}', NULL, '0', 'Offline')";
		
				$result = mysql_query($sql, $conn);
			
				if($result)
				{
					echo "true";
				}
				else
				{
					echo "false";
				}
				
		}
		else
		{
			die("Cannot select database!<br />" . mysql_error());
		}
	}
	else 
	{
		die("Cannot connect to database!<br />" . mysql_error());
	}
}
else 
{
	echo "<h1>Sorry, you have no place here :)</h1>";
}
?>