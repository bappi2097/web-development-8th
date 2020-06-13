<form action="add.php" method="POST">
    Student ID <input type="text" name="student_id"><br>
    email <input type="email" name="email"><br>
    password <input type="password" name="password"><br>
    <input type="submit" name="addData" value="Send Data To Server"><br>
</form>

<?php
    include_once "Curd.php";
    $curd = new Curd();

    if(isset($_POST['addData'])){
        $student_id = $_POST['student_id'];
        $email = $_POST['email'];
        $password = md5($_POST['password']);
        $sql = "INSERT into info(student_id,email,password)
        VALUES('$student_id','$email','$password')";

        $result = $curd->execute($sql);

        if($result){
            //echo "Data Added Successfully";
            header('location:show.php');
        }else{
            echo "Insertion problem";
        }
    }
?>