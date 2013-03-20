$(document).ready(function()
{
	$.getScript('/resources/js/colors.js',function(){
	    $("#text").attr('maxlength','140');
	    $("#text").attr('placeholder','Enter message here...');
	    $("#text").focus(function()
	    {
	        $("#text").css('border','1px solid '+vitamin_c);
	    });
	    $("#text").blur(function()
	    {
	        $("#text").css('border','0 none #000');
	    });
	    $("body").css('background-color',whitish_grey);
	    $("header").css('background-color',barely_chalk);
	    $("#header").css('background-color',barely_chalk);
	    $("#title").css('color',qwhite);
	});
    
});

