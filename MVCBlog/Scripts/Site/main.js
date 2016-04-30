(function ($) {
    "use strict";
	$(document).ready(function() {
		$('#carousel-example-generic1').carousel({
		  interval: 1600
		});		
		$('.header_submit').attr('value','');
		$('.fm_newsletter').attr('value','');
		
		$('.header_submit') .on('click', function(){
            $('.header_input').toggleClass('display_block');
        });	
	});
});