//Promises
//it is used in asynchronous execution model

function divide(n1,n2){
    return new Promise((resolve,reject)=>{
        setTimeout(()=>{
            if(n2===0){
                reject("Divide by zero");
            }else{
                resolve(n1/n2);
            }        
        },3000);
    });    
}


console.log('start of script');
let a=10,b=2;
divide(a,b).then(result=>{
    console.log('result:',result);
}).catch(err=>{
    console.log('error occurred:',err);
});
console.log('end of script');