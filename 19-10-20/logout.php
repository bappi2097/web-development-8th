<?php
	session_start();
	$_SESSION['email']=null;
	$_SESSION['user_type']=null;
	session_destroy();
	header('location:Login.php');
?>