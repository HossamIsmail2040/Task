import { Router } from '@angular/router';
import { EmpolyeeService } from './../../Services/empolyee.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginResponse } from 'src/app/Model/Response/LoginResponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  protected form! : FormGroup ;
  constructor(private fb : FormBuilder , private service : EmpolyeeService , private router : Router) {
    this.form = this.fb.group({
      userName : ['' , Validators.required] ,
      password : ['' , Validators.required]
    })
   }

  ngOnInit(): void {
  }

  save()
  {
     this.service.Login(this.form.value)
                 .subscribe(
                  (res : LoginResponse)=>{
                    sessionStorage.setItem('token' , res.accessToken),
                    sessionStorage.setItem('userName' , res.userName),
                    this.router.navigate(['/Dashboard'])
                  },
                  (err)=> console.log(err)
                 )
  }
}
