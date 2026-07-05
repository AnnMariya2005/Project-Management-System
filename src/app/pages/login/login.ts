import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})
export class Login {

  loginForm: FormGroup;

  showPassword = false;

  constructor(
    private fb: FormBuilder,
    private router: Router
  ) {

    this.loginForm = this.fb.group({

      username: ['', Validators.required],

      password: ['', Validators.required]

    });

  }

  togglePassword() {

    this.showPassword = !this.showPassword;

  }

  login() {

    if(this.loginForm.invalid){

      this.loginForm.markAllAsTouched();

      return;

    }

    // API integration later
    this.router.navigate(['/dashboard']);

  }
  forgotPassword() {

  this.router.navigate(['/change-password']);

}


}