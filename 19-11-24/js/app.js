$(document).ready(function(){
	$('#add_data').hide();
	$.get('functions/show.php',function(response1){
		$('#show_data').html(response1);
	})

	$('#addData').click(function(){
		var student_id=$('#student_id').val();
		var email=$('#email').val();
		var password=$('#password').val();
		//console.log(student_id);
		$.ajax({
			url:"functions/add.php",
			type:"POST",
			data:{s_id: student_id, s_email: email, s_password: password},//there we use s_id as a index
			success: function(response){
				//console.log(response);
				if(response=="success") {
					console.log(response);
					$('#student_id').val('');
					$('#email').val('');
					$('#password').val('');
					$('#add_data').slideUp();
					$.get('functions/show.php',function(data){
						$('#show_data').html(data);
					})
				}
				else{
					$("#show_data").html("<p style='color:red;'>Doesn't Save</p>");
				}
				//toaster library
				//.htaccess/laravel
			}
		})
	})
})