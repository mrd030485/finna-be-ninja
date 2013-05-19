$(document).ready(function(){
  $("#header #menu ul li span").click(function(){
   if($("#header #menu ul li").hasClass("parent")){
         $(".parent ul").hide();
             $("ul li.parent").removeClass("parent");
   }else{
      $("#menu>ul>li").has('ul').addClass("parent");
       $(".parent ul").show();
   }
  })
});
