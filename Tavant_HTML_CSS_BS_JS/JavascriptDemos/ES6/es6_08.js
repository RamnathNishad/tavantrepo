//callbacks and Promises
//callback function is a function passed as an argument to another function
//it is used in asynchronous execution model

function divide(n1,n2,cb){
    setTimeout(()=>{
        if(n2===0){
            cb("Divide by zero");
        }else{
            cb(null,n1/n2);
        }        
    },3000);    
}


console.log('start of script');
let a=10,b=2;
divide(a,b,(err,result)=>{
    if(err){
        console.log('error occurred:',err);
    }else{
        console.log('result:',result);
    }
});
console.log('end of script');