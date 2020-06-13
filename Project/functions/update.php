<?php
    include_once "../classes/Curd.php";
    $curd = new Curd();

    
        $student_id = $_POST['s_id'];
        $email = $_POST['s_email'];
        //$password = md5($_POST['password']);
        $id=$_POST['param_id'];
        $sql = "update info set student_id='$student_id',email='$email' where id=$id";

        $result = $curd->execute($sql);

        if($result){
            echo "success";
            //echo "Data Added Successfully";
            //header('location:show.php');
        }else{
            echo "Update problem";
        }
    
?>