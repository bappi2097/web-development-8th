<?php
    session_start();
    if(!isset($_SESSION['email'])){
        header('location:Login.php');
    }
?>
<a href="addcourse.php"></a>
<?php
    include_once "Curd.php";
    $curd = new Curd();
    $result = $curd->getData("SELECT * from course order by id DESC");
    $sum_sgpa=0;
    $sgpa=0;
    $credit=0;
    $sum_credit=0;
    $total_sgpa=0;
    echo "<table border='1'><tr><th>Course Id</th>
    <th>Course Name</th>
    <th>Course Credit</th>
    <th>SGPA</th></tr>";
    foreach($result as $row){
        echo "<tr><td>".$row['course_id']."</td>";
        echo "<td>".$row['course_name']."</td>";
        $credit=(float)$row['course_credit'];
        echo "<td>".$credit."</td>";
        $sgpa=(float)$row['course_sgpa'];
        echo "<td>".$sgpa."</td></tr>";
        $sum_sgpa+=$credit*$sgpa;
        $sum_credit+=$credit;

        //echo "<td><a href='edit.php?id=$row[id]'>Edit</a> | <a href='delete.php?id=$row[id]'>Delete</a>";
    }
    echo "<tr><td colspan='3'>Total SGPA</td><td>".number_format(($sum_sgpa/$sum_credit),'2')."</td></tr>";
    echo "</table>";
    echo "<a href='addcourse.php'>Add Course</a>";
?>