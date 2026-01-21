import { Component ,inject} from '@angular/core';
import { Calculatorservice } from '../../services/calculatorservice';
@Component({
  selector: 'app-calculator',
  imports: [],
  templateUrl: './calculator.html',
  styleUrl: './calculator.css',
})
export class Calculator {
  private calculatorservice=inject(Calculatorservice);
  a:number=10;
  b:number=2;
  additionResult=this.calculatorservice.add(this.a,this.b);
  subtractionResult=this.calculatorservice.subtract(this.a,this.b);
  multiplicationResult=this.calculatorservice.multiply(this.a,this.b);
  divisionResult=this.calculatorservice.divide(this.a,this.b);

}
