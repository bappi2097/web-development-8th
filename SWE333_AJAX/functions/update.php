<?php
    include_once "../classes/Crud.php";
    $crud = new Crud();

        $student_id = $_POST['s_id'];
        $email = $_POST['s_email'];
        $id = $_POST['param_id'];
        $sql = "Update info SET student_id='$student_id',email='$email' where id=$id";

        $result = $crud->execute($sql);

        if($result){
           echo "Success";
            
        }else{
            echo "Update problem";
        }
  
?>