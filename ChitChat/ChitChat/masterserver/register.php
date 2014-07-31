<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to register a user:
*/

if (isset($_POST['username'])) 
{

	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);

	if ($conn) 
	{
		$select_db = mysql_select_db(DB_NAME, $conn);

		if ($select_db) 
		{
			//Assing variables sent from the program
			$username =	mysqli_real_escape_string($conn, $_POST['firstname']);
			$password = mysqli_real_escape_string($conn, $_POST['password']);
			$email 	  = mysqli_real_escape_string($conn, $_POST['email']);
			$ip		  = mysqli_real_escape_string($conn, $_POST['ip']);
			$sex 	  = mysqli_real_escape_string($conn, $_POST['sex']);
		
				$sql  = "SELECT * FROM users WHERE email = '{$email}'"
				$result = mysql_query($sql, $conn);
				$row = mysql_fetch_assoc($result);
				if(mysql_num_rows($result)) 
				{
					die("Email already registered");
				}
				
				$sql  = "SELECT * FROM users WHERE username = '{$username}'"
				$result = mysql_query($sql, $conn);
				$row = mysql_fetch_assoc($result);
				if(mysql_num_rows($result)) 
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