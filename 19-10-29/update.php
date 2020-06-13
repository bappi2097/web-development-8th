<?php
    session_start();
    if(!isset($_SESSION['email'])){
        header('location:Login.php');
    }
?>
<?php
    include_once "Curd.php";
    $curd = new Curd();

    if(isset($_POST['update'])){
        $student_id = $_POST['student_id'];
        $email = $_POST['email'];
        $password = md5($_POST['password']);
        $id=$_POST['id'];
        $sql = "update info set student_id='$student_id',email='$email' where id=$id";

        $result = $curd->execute($sql);

        if($result){
            //echo "Data Added Successfully";
            header('location:show.php');
        }else{
            echo "Insertion problem";
        }
    }
?>