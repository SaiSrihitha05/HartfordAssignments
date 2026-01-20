import { Component, inject } from '@angular/core';
import { Arrayservice } from '../../services/arrayservice';

@Component({
  selector: 'app-arraycomponent',
  imports: [],
  templateUrl: './arraycomponent.html',
  styleUrl: './arraycomponent.css',
})
export class Arraycomponent {
  private res=inject(Arrayservice);
  a:string[]=[]
  ngOnInit(){
    this.res.addData(['banana','apple'])
    this.a= this.res.getData();
  }
    
}
