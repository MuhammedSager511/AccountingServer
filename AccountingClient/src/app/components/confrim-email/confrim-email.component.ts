import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-confrim-email',
  standalone: true,
  imports: [],
  template:`
    <div style="height: 90vh; display: flex; flex-direction: column; align-items: center; justify-content: center; text-align: center;">
      <h1 style="font-size: 2.5rem; color: #333; margin-bottom: 20px;">{{response}}</h1>
      <div style="font-size: 1.3rem; color: #666;">
        To return to the login page, 
        <a href="/login" style="color: #007BFF; text-decoration: none;">click here...</a>
      </div>
    </div>

  `
})
export class ConfrimEmailComponent {

  email:string=" ";
  response:string="Email confirmation";
  
  constructor(
    private activated:ActivatedRoute,
    private http:HttpService
  ) {
   this.activated.params.subscribe(res=>{
    this.email=res["email"];
    this.confirm()
   })
  }
  confirm(){
    this.http.post<string>("Auth/ConfirmEmail",{email:this.email},(res)=>{
      this.response=res;
    })
  }
}
