<?php
    header('Access-Control-Allow-Origin: *');
    include_once "../classes/Curd.php";
    $curd = new Curd();
    $result = $curd->getData("SELECT * from info order by id DESC");
    if($result){
        echo "<table border='1'><tr><th>STUDENT ID</th>
        <th>Email</th>
        <th>Action</th></tr>";
        foreach($result as $row){
            echo "<tr><td>".$row['student_id']."</td>";
            echo "<td>".$row['email']."</td>";
            echo "<td><a href='edit.php?id=$row[id]'>Edit</a> | <a href='delete.php?id=$row[id]'>Delete</a>";
        }
        echo "</table>";
    }
    else{
        echo "No Data Found! Please Add Data.";
    }
?>