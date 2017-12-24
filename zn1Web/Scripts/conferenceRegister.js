$('document').ready(function () {
	$('#submit-register-form').on('click', function (e) {
		if ($('#register-form').valid()) {
			$.ajax({
				url: $('#register-form').attr('action'),
				type: $('#register-form').attr('method'),
				data: $('#register-form').serialize(),
				success: function (response) {
					$('#confirm-modal').modal('show');
				}
			});
		}
	})
});