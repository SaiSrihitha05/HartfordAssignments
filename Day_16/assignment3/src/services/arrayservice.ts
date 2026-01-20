import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Arrayservice {
  array:string[]=[]
  getData(){
    return this.array;
  }
  addData(s:string[]){
    s.forEach((e)=>{
      this.array.push(e);
    })
    
  }
}
