<?php
	session_start();
    include_once "Curd.php";
    $curd = new Curd();

    if(isset($_POST['email'])){
        $email = $_SESSION['email'];
        $sql = "update login set isAdmin='2' where email='$email'";

        $result = $curd->execute($sql);

        if($result){
            //echo "Data Added Successfully";
            echo "Successfully send request";
        }else{
            echo "Insertion problem";
        }
    }
?>
<?php
	//session_start();
	if(!isset($_SESSION['email'])){
		header('location:Login.php');
	}else{
		if($_SESSION['user_type']=="both"){
			echo "<h1>User and Admin</h1><br>
				<a href='admin.php'>View admin page</a>";
		}else if($_SESSION['user_type']=="user"){
			echo "<h1>User</h1><br>
				<form action='user.php' method='POST'><input type='button' name='request' value='request for admin'></form>";
		}else if($_SESSION['user_type']=="admin"){
			header('location:admin.php');
		}
	}
?>
<a href="logout.php">Logout</a>