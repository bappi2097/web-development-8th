<form method="POST" action="add.php">

	student ID: <input type="text" name="student_Id"/></br>
	Email: <input type="email" name="email"/></br>
	Password: <input type="password" name="password"/></br>
	<input type="submit" name="addData"/>

</form>

<?php

	include_once "crud.php";
	$crud = new Crud(); // Crud method in crud class
	if(isset($_POST['addData'])){
		$student_Id = $_POST['student_Id'];
		$email = $_POST['email'];
		$password = md5($_POST['password']);//md5 build encription method

		$sql = "INSERT into info(student_id,email,password) VALUES('$student_Id','$email','$password')";

		$result = $crud->execute($sql);

		if($result){
			header('location:index.php');
		}
		else{
			echo "Insertion Problem!";
		}
	}

?>