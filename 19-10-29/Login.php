<?php
	session_start();
	include_once "Curd.php";
	$crud=new Curd();
	if(isset($_POST['login'])){
		$email=$_POST['email'];
		$password=md5($_POST['password']);

		$sql="SELECT * FROM login WHERE email='$email' and password='$password'";
		$result=$crud->getData($sql);

		
		if(!empty($result)){
			$_SESSION['email']=$email;
			$_SESSION['user_type']="none";
			foreach ($result as $raw) {
				$isAdmin=$raw['isAdmin'];
				$isUser=$raw['isUser'];
			}
			if($isAdmin==1 && $isUser==1){
				$_SESSION['user_type']="both";
				//header('location:both.php');
			}
			else if($isAdmin==1){
				$_SESSION['user_type']="admin";
				//header('location:admin.php');
			}
			else if($isUser==1){
				$_SESSION['user_type']="user";
				//header('location:user.php');
			}
			header('location:user.php');
			
		}else{
			echo "Login Problem";
		}
	}
?>
<form action="Login.php" method="POST">
	Email:</br>
	<input type="email" name="email" placeholder="Enter Your Email"></br>
	Password:</br>
	<input type="password" name="password" placeholder="Enter your password"></br>
	<input type="submit" name="login" value="Login">
</form>