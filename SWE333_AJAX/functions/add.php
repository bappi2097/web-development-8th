<?php
    include_once "../classes/Crud.php";
    $crud = new Crud();

 
        $student_id = $_POST['s_id'];
        $email = $_POST['s_email'];
        $password = md5($_POST['s_pass']);
        $sql = "INSERT into info(student_id,email,password)
        VALUES('$student_id','$email','$password')";

        $result = $crud->execute($sql);

        if($result){
            echo "success";
        }else{
            echo "Insertion problem";
        }
    
?>