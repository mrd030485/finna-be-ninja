$(document).ready(function()
{
    $("#stmtText").attr('maxlength','140');
    $("#stmtText").attr('placeholder','Enter message here...');
    $("#stmtText").focus(function()
    {
        $("#stmtText").css('border','1px solid #cccc99');
    });
    $("#stmtText").blur(function()
    {
        $("#stmtText").css('border','0 none #000');
    });
});

