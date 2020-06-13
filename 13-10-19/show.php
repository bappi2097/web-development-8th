<a href="add.php"></a>
<?php
    include_once "Curd.php";
    $curd = new Curd();
    $result = $curd->getData("SELECT * from info order by id DESC");

    echo "<table border='1'><tr><th>STUDENT ID</th>
    <th>Email</th>
    <th>Password</th></tr>";
    foreach($result as $row){
        echo "<tr><td>".$row['student_id']."</td>";
        echo "<td>".$row['email']."</td>";
        echo "<td>".$row['password']."</td></tr>";
    }
    echo "</table>"
?>