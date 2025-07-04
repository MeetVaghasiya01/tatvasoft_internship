import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  imports: [CommonModule,FormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent {
  userName = ''
  userPassword = ''

  listen() {
    console.log("UserName: "+this.userName);
    console.log("UserPassword: "+this.userPassword);
  }

}
