/*global $, document,  */

/* styleford */




//******************** Start Loading screen **************************************
$(window).on('load', function () {
	'use strict';
	
	$('.loading .sk-chase, .loading').fadeOut(1000, function () {
		// show the scroll
		$('body,html').css('overflow', 'auto');
		
		// remove loading div from Html
		$(this).remove();
		
		
	});
	
	
});

//******************** End Loading screen ******************************************

//page go to top on reload
window.onbeforeunload = function () {
	'use strict';
	window.scrollTo(0, 0);
};



$(document).ready(function () {
	'use strict';
	
	
	//********************Start add active class to navbar on click *********************
	
	//// remove class active from all "li" 
	//$('.navbar-collapse li').removeClass('active');
	
	//// add class active to home based on url
	//if (window.location.href.indexOf("index.html") > -1) {
	//	$('.navbar-collapse').find('[href="index.html"]').parent().addClass('active');
	//}
	
	//// add class active to "li" that has same data-paga as clicked link
	//$('.navbar-collapse').find("[data-page='" + sessionStorage.getItem("activeNav") + "']").parent().addClass('active');
	
	//// store the attr [data-page] in local storage when click 
	//$('[data-page]').on('click', function () {
	//	sessionStorage.setItem("activeNav", this.getAttribute("data-page"));
	//});
	
	//**************************End add active class to navbar on click ********************
		
	//***************** Start show/ hide search bar ********************
	$('.search_close_open').on('click', function () {
		$('.search_bar').slideToggle(0);
		
		//-------------- show / hide close icon ---------
		
		$('.search_close_open').toggleClass('opacity_0');
	});
	
	
	
	
	//***************** End show/ hide search bar ********************
	
	
	//***************** Start show/ hide options ********************
	$('.open_opotions_01').on('click', function () {
		
		$('.side .options_01').toggleClass('d-none');
	});
	
	$('.open_opotions_02').on('click', function () {
		
		$('.side .options_02').toggleClass('d-none');
	});
	
	
	
	//***************** End show/ hide options ********************
	

	//***************** Start scroll to top button ******************************************
	// variables for scroll to top button
	var scrollButton = $('.scroll_top'),
		page = $('html');
	$(scrollButton).on('click', function () {
		$(page).animate({
			scrollTop: '0'
		}, 1500);
	});
	
	// Show & hide scroll button on scroll
	$(window).on('scroll', function () {
		
		if ($(this).scrollTop() > 500) {
			$(scrollButton).show();
			
		} else {
			$(scrollButton).fadeOut(500);
		}
	});


	
	
	
	
	
	
});


