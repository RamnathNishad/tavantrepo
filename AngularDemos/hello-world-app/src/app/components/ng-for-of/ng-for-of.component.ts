import { Component } from '@angular/core';

@Component({
  selector: 'app-ng-for-of',
  templateUrl: './ng-for-of.component.html',
  styleUrls: ['./ng-for-of.component.css']
})
export class NgForOfComponent {
 names = ['John', 'Doe', 'Jane', 'Doe'];
 people=[
  {name:'Ramnath',age:25,city:'Bangalore',picture:'assets/images/1.jpg'},
  {name:'Rohit',age:15,city:'Chennai',picture:'assets/images/2.jpg'},
  {name:'Sunita',age:35,city:'Mumbai',picture:'assets/images/3.jpg'},
  {name:'Rahul',age:10,city:'Delhi',picture:'assets/images/4.jpg'}  

 ];

 imgStyle={
  'height.px':100,
  'width.px':70,
  'border-radius.px':5,
  'margin.px':5
 }


 deletePerson(i:number){
    this.people.splice(i,1);
 }
 getCssClass(age:number){
   return age<18?'text-danger':'text-success';
 }
}
