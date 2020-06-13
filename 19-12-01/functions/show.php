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
            echo "<td><button id='".$row['id']."' class='editView'>Edit</button> | <button id='".$row['id']."' class='delete'>Delete</button></td></tr>";
        }
        echo "</table>";
    }
    else{
        echo "No Data Found! Please Add Data.";
    }
?>
<script type="text/javascript">
    $(document).ready(function(){
        $('.editView').on('click', function(){
            //alert('worked');
            var id = $(this).attr('id');
            //alert(id);
            $.ajax({
                url: "functions/edit.php",
                type: "POST",
                data: {param_id:id},
                success: function(response){
                    $('#edit_data').slideDown();
                    $('#edit_data').html(response);
                }
            })
        
        })
        $('.delete').on('click', function(){
            //alert('worked');
            var id = $(this).attr('id');
            //alert(id);
            $.ajax({
                url: "functions/delete.php",
                type: "POST",
                data: {param_id:id},
                success: function(response){
                    console.log(response);
                    if(response=="success"){
                        $.get('functions/show.php', function(data){
                            $('#show_data').html(data);
                        })
                    }
                }
            })
        
        })
    })
</script>