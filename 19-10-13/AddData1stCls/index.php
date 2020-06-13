<?php
	
	include_once "crud.php";
	$crud = new Crud();
	$result = $crud->getData("SELECT * FROM info order by id DESC");

	echo "<table><tr><th>Student ID</th>
	<th>Email</th>
	<th>Password</th>";
	foreach($result as $row){

		echo "<tr><td>".$row['student_id']."</td>";
		echo "<td>".$row['email']."</td>";
		echo "<td>".$row['password']."</td></tr>";

	}

	echo "</table>";

?>

<a href='add.php'> ADD DATA </a>