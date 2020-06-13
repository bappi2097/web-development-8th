<?php
    include_once "../classes/Crud.php";
    $crud = new Crud();
    $result = $crud->getData("SELECT * from info order by id DESC");
	
	if($result){
		echo "<table border='1' id='show_table'><thead><tr><th>STUDENT ID</th>
		<th>Email</th>
		<th>Action</th></tr></thead><tbody>";
		
		foreach($result as $row){
			echo "<tr><td >".$row['student_id']."</td>";
			echo "<td>".$row['email']."</td>";
			
			echo "<td><button id='".$row['id']."' class='editView'>Edit</button> | <button id='".$row['id']."' class='delete'>Delete</button></td></tr> ";
		}
		echo "</table></tbody>";
	}else{
		echo "No Data Found! Please Add Data.";
	}
?>
<script type="text/javascript">
$(document).ready(function(){
	$('#show_table').DataTable();
	$('.editView').on('click',function(){
		var id = $(this).attr('id');
		//alert(id);
		$.ajax({
			url:"functions/edit.php",
			type:"POST",
			data:{param_id:id},
			success: function(response){
				$('#edit_data').slideDown();
				$('#edit_data').html(response);
			}
		})
	})
	$('.delete').on('click',function(){
		var id = $(this).attr('id');
		//alert(id);
		$.ajax({
			url:"functions/delete.php",
			type:"POST",
			data:{param_id:id},
			success: function(response){
				
				if(response == "success"){
					$.get('functions/show.php',function(data){
						$('#show_data').html(data);
					})
				}
			}
		})
	})
})
</script>