<?php
define("DB_NAME", "chitchat");
define("DB_USER", "chitchat");
define("DB_PASS", "123456");
define("DB_HOST", "127.0.0.1");

function mysql_prep( $value ) {
		$magic_quotes_active = get_magic_quotes_gpc();
		$new_enough_php = function_exists( "mysql_real_escape_string" ); // i.e. PHP >= v4.3.0
		if( $new_enough_php) { //PHP v4.3.0 or higher
			// undo any magic quoute effect so mysql_real_escape_string can do the work
		if( $magic_quotes_active ) { $value = stripslashes( $value ); }
		$value = mysql_real_escape_string( $value );
		} else { // before PHP v4.3.0
			//if magic quotes are't already on then add slashes manually
		if( !$magic_quotes_active ) {$value = addslashes ( $value ); }
			//if magic quotes are active, then the slashes already exist
		}
		return $value;
	}
?>