//spread operator(3 dots)
//works with objects and arrays

//spread operator with arrays
let num1=[10,20,30,40];
let num2=[...num1];
num2.push(50);
console.log('num1:',num1);
console.log('num2:',num2);

//spread operator with objects
let p1={name:'Ramnath',email:'raman9999@gmail.com'};
let p2={...p1,city:'Bangalore'};
p2.name='Raman';
console.log('p1:',p1);
console.log('p2:',p2);

