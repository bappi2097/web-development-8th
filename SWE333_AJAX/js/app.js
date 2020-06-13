$(document).ready(function(){
	
	$('#add_data').hide();
	
	$.get('functions/show.php',function(data){
		$('#show_data').html(data);
	})
	
	$('#addData').click(function(){
		
		var student_id = $('#student_id').val();
		var email = $('#email').val();
		var password = $('#password').val();
		
		//console.log(student_id);
		$.ajax({
			url:"functions/add.php",
			type:"POST",
			data:{s_id:student_id,s_email:email,s_pass:password },
			success: function(response){
				//console.log(response);
				if(response == "success"){
					$('#student_id').val('');
					$('#email').val('');
					$('#password').val('');
					$('#add_data').slideUp();
					$.get('functions/show.php',function(data){
						$('#show_data').html(data);
					})
				}
			}
		})
	})
})