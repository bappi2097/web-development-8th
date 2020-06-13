<?php
	session_start();
	if(!isset($_SESSION['email'])){
		header('location:Login.php');
	}
?>
<form action="addcourse.php" method="POST">
    Course Id <input type="text" name="course_id"><br>
    Course Name <input type="text" name="course_name"><br>
    Course Credit <input type="text" name="course_credit"><br>
    SGPA <input type="text" name="course_sgpa"><br>
    <input type="submit" name="addCourseData" value="Send Data To Server"><br>
</form>

<?php
    include_once "Curd.php";
    $curd = new Curd();

    if(isset($_POST['addCourseData'])){
        $course_id = $_POST['course_id'];
        $course_name = $_POST['course_name'];
        $course_sgpa = $_POST['course_sgpa'];
        $course_credit = $_POST['course_credit'];
        $sql = "INSERT into course(course_id,course_name,course_sgpa,course_credit)
        VALUES('$course_id','$course_name','$course_sgpa','$course_credit')";

        $result = $curd->execute($sql);

        if($result){
            //echo "Data Added Successfully";
            header('location:showcourse.php');
        }else{
            echo "Insertion problem";
        }
    }
?>