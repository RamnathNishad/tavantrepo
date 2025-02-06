//defining class in ES6
class Person {

    //if u want to define fields, put constructor
    constructor(name,city){
        this.name = name;
        this.city = city;
    }
    display(){
        console.log('Name: '+this.name);
        console.log('City: '+this.city);
    }
}
//create object of class
let p1 = new Person('Raj','Pune');
let p2= new Person('Ravi','Mumbai');
//console.log(p1);
//console.log(p2);
p1.display();
p2.display();

//=================inheritance====================
class Employee extends Person{
    constructor(name,city,deptid){
        super(name,city);
        this.deptid=deptid;
    }
}

let e1 = new Employee('Raj','Pune',201);
console.log(e1);

//Note: 
//*we define constructor of a class using special keyword constructor()
//*if u define constructor in derived class also, we must
//call base class ctor first inside the class ctir using super()
//*avoid using this keyword befoer super() statement