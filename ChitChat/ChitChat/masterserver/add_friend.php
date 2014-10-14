<?php
include "config.php";

if(isset($_POST['user_id']))
{
	$user_id   = mysql_real_escape_string($_POST['user_id']);
	$friend_id = mysql_real_escape_string($_POST['friend_id']);
	
	$conn = mysql_connect(DB_HOST, DB_USER, DB_PASS);
	if($conn)
	{
		$select_db = mysql_select_db(DB_NAME, $conn);
		
		if($select_db)
		{
			$sql = "INSERT INTO contacts (`user_id`, `friend_id`, `accepted`) VALUES ('{$user_id}', '{$friend_id}', '0')";
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
	}
}