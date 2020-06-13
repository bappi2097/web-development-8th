<?php
    include_once "../classes/Crud.php";
    $crud = new Crud();

    $id = $_POST['param_id'];

    if($crud->delete($id,'info')){
        echo "success";
    }
?>
