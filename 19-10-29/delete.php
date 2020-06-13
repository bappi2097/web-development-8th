<?php
	session_start();
	if(!isset($_SESSION['email'])){
		header('location:Login.php');
	}
?>
<?php 
	include_once "Curd.php";
	$crud = new Curd();

	$id=$_GET['id'];
	if($crud->delete($id,'info')){
		header('location:show.php');
	}
 ?>