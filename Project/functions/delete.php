<?php 
	include_once "../classes/Curd.php";
	$crud = new Curd();

	$id=$_POST['param_id'];
	if($crud->delete($id,'info')){
		echo "success";
	}
 ?>