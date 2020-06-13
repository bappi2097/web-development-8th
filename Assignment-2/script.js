document.write(12+"<br>");
console.log(12);
var name = "Bappi Saha";
var age = 20;
document.getElementById("name").innerHTML= "Name : "+name
                                          +"<br>Age : "+age+"<br>";

var a=Math.ceil(Math.random()*20);
var b=Math.ceil(Math.random()*20);
var x=Number(prompt(" "+a+" * "+b+""+" = ?"));
if(confirm("Are You Sure")){
  if(x==a*b)alert("Right answer");
  else {
    while(parseInt(prompt("Enter Right Answer"))!=a*b);
  }
}
document.write("bappi".toUpperCase(),"<br>");
var w = "BaPpI SaHa"
document.write(w.toLowerCase(),"<br>");
document.write(w.toUpperCase(),"<br>");
document.write(w.small(),"<br>");
document.write(w.bold(),"<br>");
document.write(w.strike(),"<br>");
document.write(w.fontsize("5em"),"<br>");
document.write(w.link("www.facebook.com"),"<br>");
document.write(w.fontcolor("red").fontsize("10em"),"<br>");
var arr = [15,30,"bappi"];
for(a in arr)document.write(arr[a]," ");
document.write("<br>");
document.write(arr.pop(),"<br>");
document.write("Leangth Of Array : ",arr.length,"<br>");
var grade='A';
document.write("Grade "+grade+" : ");
switch(grade){
  case 'A':
    document.write("Very Good grade!");
    break;
  case 'B':
    document.write("Good grade!");
    break;
  default:
    document.write("Enter correct grade!");
    break;
}
document.write("<br>");
for(j=0;j<5;j++)document.write(j+" ");
document.write("<br>");
var i=0;
do{
  document.write(i+" ");
  i++;
}while(i<5);
document.write("<br>");
var add2Num=function(num1,num2){
  return num1+num2;
}
var sum=add2Num(2,3);
document.write("2 + 3 = ",sum,"<br>");
function aleartMessage(message){
  alert(message);
}
aleartMessage("Error");
