//templated string
let s1='my name is Ramnath';
let s2="i live in Bangalore";
let s3="this is 'javascript' training";
let s4='this training is on "javascript"';

console.log(s1);
console.log(s2);
console.log(s3);
console.log(s4);

//templated string can be substituted with variables
let name='Ramnath';
let email="raman9999@gmail.com";
let s6=`Email address of ${name} is ${email}`;
console.log(s6);

//multiline string
let s7=`This is a new feature of ES6.
this is multiline text`;
console.log(s7);

//we can use expression also inside the string
let age=10;
let s8=`${name} is ${age<18?'a minor':'an adult'}`;
console.log(s8);


