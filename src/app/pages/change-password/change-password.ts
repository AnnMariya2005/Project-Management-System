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
  selector: 'app-change-password',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './change-password.html',
  styleUrl: './change-password.scss'
})
export class ChangePassword {

  passwordForm: FormGroup;

  showCurrent = false;
  showNew = false;
  showConfirm = false;

  constructor(
    private fb: FormBuilder,
    private router: Router
  ){

    this.passwordForm=this.fb.group({

      currentPassword:['',Validators.required],

      newPassword:['',Validators.required],

      confirmPassword:['',Validators.required]

    });

  }

  save(){

    if(this.passwordForm.invalid){

      this.passwordForm.markAllAsTouched();

      return;

    }

    if(this.passwordForm.value.newPassword!==this.passwordForm.value.confirmPassword){

      alert("Passwords do not match");

      return;

    }

    alert("Password changed successfully");

    this.router.navigate(['/login']);

  }

}