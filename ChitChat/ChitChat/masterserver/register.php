<?php
include "config.php";
/* 
ChitChat MasterServer

Functions to register a user:
*/

if (isset($_POST['username'])) 
{
	//Assing variables sent from the program
	/*$username =	mysql_prep($_POST['username']);
	$password = mysql_prep($_POST['password']);
	$email 	  = mysql_prep($_POST['email']);
	$ip		  = mysql_prep($_POST['ip']);
	$sex 	  = mysql_prep($_POST['sex']);*/
	
	$username =	$_POST['username'];
	$password = $_POST['password'];
	$email 	  = $_POST['email'];
	$ip		  = $_POST['ip'];
	$sex 	  = $_POST['sex'];
	
	$bEmail;
	$bUsername;

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
					die("Username");
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
					die("Email");
					$bEmail = false;
				}
				else
				{
					$bEmail = true;
				}
				
				$sql  = "INSERT INTO users (`username`, `password`, `email`, `joinDate`, `ip`, `info`, `city`, `nation`, `phone`, `sex`, `name`, `isDonator`, `onlineStance`) 
						VALUES ('{$username}', '{$password}', '{$email}', now(), '{$ip}', NULL, NULL, NULL, NULL, '{$sex}', NULL, '0', 'Offline')";
			
				$result = mysql_query($sql, $conn);
				
				if($result)
				{
					die("true");
				}
				else
				{
					die("false");
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