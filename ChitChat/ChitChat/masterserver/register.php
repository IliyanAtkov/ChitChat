<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to register a user:
*/

if (isset($_GET['username'])) 
{
	//Assing variables sent from the program
	$username =	$_GET['username'];
	$password = $_GET['password'];
	$password = md5($password);
	$email 	  = $_GET['email'];
	$ip		  = $_GET['ip'];
	$sex 	  = $_GET['sex'];
	
	$bEmail;

	//Attempt mysql connection
	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);

	if ($conn) //If succeeded
	{
		//Select database
		$select_db = mysql_select_db(DB_NAME, $conn);

		
		if ($select_db) //If succeeded
		{	
				$checkUsernameSQL = "SELECT id FROM users WHERE username = '{$username}'";
				$result = mysql_query($checkUsernameSQL);
				if(mysql_num_rows($result) >= 1)
				{
					echo "Username exists";
					$bUsername = false;
				}
				else
				{
					$bUsername = true;
				}
				
				$checkEmailSQL = "SELECT id FROM users WHERE email = '{$email}'";
				$result = mysql_query($checkEmailSQL);
				if(mysql_num_rows($result) >= 1)
				{
					echo "Email exists";
					$bEmail = false;
				}
				else
				{
					$bEmail = true;
				}
				
				if($bEmail && $bUsername)
				{
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