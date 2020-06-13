<?php
    include_once "../classes/Crud.php";
    $crud = new Crud();

    $id = $_POST['param_id'];
   
    $result = $crud->getData("SELECT * from info where id=$id");
    foreach($result as $res){
      $student_id = $res['student_id'];
      $email = $res['email'];  
    }
?>

    <input id='e_student_id' value="<?php echo $student_id; ?>" type="text"></br>
    <input id='e_email' value="<?php echo $email; ?>" type="email"></br>
    <input type="button" name="update" class="update" value="Update Info"/>
   <input type="button" onclick="$('#edit_data').slideUp();" value="Cancel">
   <script type="text/javascript">
$(document).ready(function(){
	
	$('.update').on('click',function(){
		var id = "<?php echo $id; ?>";
		var student_id = $('#e_student_id').val();
		var email = $('#e_email').val();
		$.ajax({
			url:"functions/update.php",
			type:"POST",
			    //{param : value}
			data:{param_id:id,s_id:student_id,s_email:email},
			success: function(response){
				if(response == "Success"){
					$('#student_id').val('');
					$('#email').val('');
					$('#edit_data').slideUp();
					$.get('functions/show.php',function(data){
						$('#show_data').html(data);
					})
				}
			}
		})
	})
	
	
})

</script>