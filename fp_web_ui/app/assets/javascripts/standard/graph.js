$(document).ready(function(){
  init();
});
var rawRate;
var recRate;

var raw;
var rec;

var rec_vs_raw;
var h=400;
var w=800;

function init(){
  rawRate = $("#rateRaw").val();
  recRate = $("#rateRecovered").val();

  raw = $("#rawCount").val();
  rec = $("#recRate").val();
  
  rec_vs_raw = rec/raw;
  $("canvas").drawRect({
    fillStyle:"#fff",
    x:400,y:200,
    width:w-60,
    height:h-60
  }).drawLine({
    strokeStyle:"#000",
    strokeWidth:3,
    x1:30, y1:30,
    x2:30, y2:h-30
  });
  for(var i=1; i<11; i++){
    $("canvas").drawLine({strokeStyle:"#000",strokeWidth:2,x1:25,y1:h-30-(i*34),x2:35,y2:h-30-(i*34)});
  }
  var scl=["0","1","2","3","4","5","6","7","8","9","10"]
  for(var t=0; t<11; t++){
     $("canvas").drawText({fillStyle:"#000",fontSize:"12pt",x:15, y:400-30-(34*t),text:scl[t]});
  }

  $("canvas").drawLine({
    strokeStyle:"#000",
    strokeWidth:1,
    x1:w-230,y1:35,
    x2:w-230,y2:75,
    x3:w-40,y3:75,
    x4:w-40,y4:35,
    closed:true
  });
  var text;
  if(rawRate>100000 && recRate>100000){
    rawScaled=rawRate/100000;
    recScaled=recRate/100000;
    text="in 100 Thousands";
  }else if(rawRate>10000 && recRate>10000){
    rawScaled=rawRate/10000;
    recScaled=recRate/10000;
    text="in 10 Thousands";
  }else if(rawRate>1000 && recRate>1000){
    rawScaled=rawRate/1000;
    recScaled=recRate/1000;
    text="in Thousands";
  }else if(rawRate>100 && recRate>100){
    rawScaled=rawRate/100;
    recScaled=recRate/100;
    text="in Hundreds";
  }else if(rawRate>10 && recRate>10){
    rawScaled=rawRate/10;
    recScaled=recRates/10;
    text="in Tens";
  }else{
    rawScaled=rawRate;
    recScaled=recRate;
    text="actual values";
  }

  $("canvas").drawText({
    fillStyle:"#000",
    x:w-220,y:50,
    fontSize:"9pt",
    text:text,
    fromCenter:false
  });
  
  $("canvas").drawRect({
    fillStyle:"#f00",
    x:100, y:h-30-(rawScaled*34),
    width:100,
    height:(rawScaled*34),
    fromCenter:false
  });
  $("canvas").drawRect({
    fillStyle:"#00f",
    x:300, y:h-30-(recScaled*34),
    width:100,
    height:(recScaled*34),
    fromCenter:false
  }).drawLine({
    strokeStyle:"#000",
    strokeWidth:3,
    x1:30, y1:h-30,
    x2:w-30, y2:h-30
    });

}
