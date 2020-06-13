<?php 
	include_once "Curd.php";
	$crud = new Curd();

	$id=$_GET['id'];
	$result = $crud->getData("select * from info where id=$id");
	foreach ($result as $row) {
		$student_id=$row['student_id'];
		$email=$row['email'];
	}
	/*if($crud->delete($id,'info')){
		header('location:show.php');
	}*/
 ?>
 <form action="update.php" method="post">
 	<input name='id' value="<?php echo $id; ?>" type="text" hidden>
 	<input name='student_id' value="<?php echo $student_id; ?>" type="text">
 	<input name='email' value="<?php echo $email; ?>" type="email">
 	<input type="submit" name="update" value="update">
 </form>