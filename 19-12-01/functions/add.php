<?php
    header('Access-Control-Allow-Origin: *');
    include_once "../classes/Curd.php";
    $curd = new Curd();

        $student_id = $_POST['s_id'];//there we use index of data
        $email = $_POST['s_email'];
        $password = md5($_POST['s_password']);
        $sql = "INSERT into info(student_id,email,password)
        VALUES('$student_id','$email','$password')";

        $result = $curd->execute($sql);

        if($result){
            //echo "Data Added Successfully";
           echo "success";
        }else{
            echo "Insertion problem";
        }
?>