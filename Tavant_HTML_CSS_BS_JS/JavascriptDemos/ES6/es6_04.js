//arrow function
function sum(a,b){
 return a+b;
}
let a=10;
let b=20;
let result=sum(a,b);
console.log('sum:',result);

//using anonymous function
let fn=function(a,b){
 return a+b;
}
result=fn(a,b);
console.log('sum:',result);

//arrow function 
let sum1=(a,b)=>{return a+b};
console.log(`sum of ${a} and ${b} is:${sum1(a,b)}`);

