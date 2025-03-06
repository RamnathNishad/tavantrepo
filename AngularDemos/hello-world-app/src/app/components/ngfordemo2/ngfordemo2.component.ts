import { Component } from '@angular/core';

@Component({
  selector: 'ngfordemo2',
  templateUrl: './ngfordemo2.component.html',
  styleUrls: ['./ngfordemo2.component.css']
})
export class Ngfordemo2Component {
 ecode?:number;
 ename?:string;
 salary?:number;
 deptid?:number;
 picture?:string;

 employees=[
  {
    ecode:this.ecode,
    ename:this.ename,
    salary:this.salary,
    deptid:this.deptid,
    picture:"assest/images/"+this.ecode?.toString()+".jpg"
  }
 ]
 
 
 addEmployee(){
  this.employees.push({
    ecode:this.ecode,
    ename:this.ename,
    salary:this.salary,
    deptid:this.deptid,
    picture:"assets/images/"+this.ecode?.toString()+".jpg"
  });
  
  this.ecode=0;
  this.ename="";
  this.salary=0;
  this.deptid=0;
 }

}
