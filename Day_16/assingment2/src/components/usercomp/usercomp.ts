import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from './interface/user';
@Component({
  selector: 'app-usercomp',
  imports: [FormsModule],
  templateUrl: './usercomp.html',
  styleUrl: './usercomp.css',
})
export class Usercomp {
  users:User[]=[];
  user:User={
    id:0,
    name:'',
    email:''
  }
  isEdit=false;
  saveUser(){
    if(this.isEdit){
      const index=this.users.findIndex(u=>u.id===this.user.id);
      this.users[index]={...this.user};
      this.isEdit=false;
    }else{
      this.user.id=Date.now();
      this.users.push({...this.user})
    }
    this.resetForm();
  }
  resetForm(){
    this.user.id=0;
    this.user.email='';
    this.user.name='';
  }
  deleteUser(id:number){
    this.users=this.users.filter(u=>u.id!==id);
  }
  editUser(selected:User){
    this.user={...selected};
    this.isEdit=true;
  }
}
