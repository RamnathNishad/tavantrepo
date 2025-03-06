import { Component } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './app-calculator.component.html',
  styleUrls: ['./app-calculator.component.css']
})
export class AppCalculatorComponent {

  x: number=100;
  y: number=20;
  result: number=0;
  imagePath: string = "assets/images/1.jpg";

  isDisabled: boolean = true;
  msg?: string="This is a message";
  age: number = 10;
  addNumbers(){
    console.log("Add numbers");
    this.result = this.x + this.y;
  }
}
