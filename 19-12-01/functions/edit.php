<?php 
	include_once "../classes/Curd.php";
	$crud = new Curd();

	$id = $_POST['param_id'];
	$result = $crud->getData("select * from info where id=$id");
	foreach ($result as $row) {
		$student_id=$row['student_id'];
		$email=$row['email'];
	}
	/*if($crud->delete($id,'info')){
		header('location:show.php');
	}*/
 ?>
 
 	<input id='e_student_id' value="<?php echo $student_id; ?>" type="text"><br>
 	<input id='e_email' value="<?php echo $email; ?>" type="email"><br>
 	<input type="button" name="update" value="update" class="update">
 	<input type="button" name="cancel" value="Cancel" onclick="$('#edit_data').slideUp();">
<script type="text/javascript">
	
	$(document).ready(function(){
		$('.update').on('click',function(){
			var id = "<?php echo $id; ?>";
			var student_id = $('#e_student_id').val();
			var email = $('#e_email').val();
			$.ajax({
				url: "functions/update.php",
				type: "POST",
				//{param : value}
				data: {param_id:id,s_id:student_id,s_email:email},
				success: function(response){
					//console.log(response);
					if(response == "success"){
						$('#student_id').val('');
						$('#email').val('');
						$('#edit_data').slideUp();
						$.get('functions/show.php', function(data){
							$('#show_data').html(data);
						})
					}
				}
			})
		})
	})
</script>