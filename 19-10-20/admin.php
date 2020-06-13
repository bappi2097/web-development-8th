<?php
    session_start();
    if(!isset($_SESSION['email'])){
        header('location:Login.php');
    }
?>
<a href="add.php"></a>
<?php
    include_once "Curd.php";
    $curd = new Curd();
    $result = $curd->getData("SELECT * from login where isAdmin='2'");

    echo "<table border='1'><tr>
    <th>Email</th>
    <th>Action</th></tr>";
    foreach($result as $row){
        echo "<td>".$row['email']."</td>";
        //echo "<td>".$row['password']."</td></tr>";
        echo "<td><a href='accept.php?id=$row[id]'>Accept</a> | <a href='reject.php?id=$row[id]'>Reject</a>";
    }
    echo "</table>"
?>
<a href="logout.php">Logout</a>