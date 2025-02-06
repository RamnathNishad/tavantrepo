//===========Higher Order Functions==============
//A higher order function is a function that takes a function as an argument, or returns a function.

//1. map() :- this function executes callback function on each 
//item on an array. It return a new array made up of return value from the callback function
//[1,2,3,4]----map(cb)---->[1,4,9,16]

let arr=[2,4,6,9,10];
let arr2=arr.map((n)=>{return `<li>${n*n}</li>`;});

console.log(arr2);
//Note: original array does not get altered and the retured array may 
//contain different elements than original array

//2. reduce() :- this function executes a callback function on each 
//item of the array and returns signle value 
let numbers=[1,2,3,4,5];
let sum=numbers.reduce((accumulator,currentValue)=>{
    return accumulator+currentValue;
},0); 
console.log('sum:',sum);

//3. forEach() :- it executes a callback function on each array items

let cities=['Mysore','Delhi','Bangalore'];
cities.forEach((c)=>{
    console.log(c);
})

//4. filter() :- this method accepts a callback function and return the filtered array based on condition specified in the callback
//function 

let numbers2=[2,11,42,14,39];
let filteredNumbers=numbers2.filter((n)=>{
    return n % 2==0;
});

console.log(numbers2);
console.log('even numbers:',filteredNumbers);