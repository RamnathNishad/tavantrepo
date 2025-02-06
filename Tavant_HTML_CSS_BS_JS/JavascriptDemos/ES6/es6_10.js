//async and await
//it is used in asynchronous execution model

function divide(n1,n2){
    return new Promise((resolve,reject)=>{        
            if(n2===0){
                reject("Divide by zero");
            }else{
                resolve(n1/n2);
            }
    });    
}


console.log('start of script');
let a=10,b=2;
setTimeout(async ()=>{
    try{
        let result = await divide(a,b);
        console.log('result:',result);
    }catch(err){
        console.log('error occurred:',err);
    }
},0);

console.log('end of script');