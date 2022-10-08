import { Router } from '@angular/router';
import { EmpolyeeService } from '../../Services/empolyee.service';
import { Empolyee } from '../../Model/Request/Empolyee';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-empolyee',
  templateUrl: './add-empolyee.component.html',
  styleUrls: ['./add-empolyee.component.scss']
})
export class AddEmpolyeeComponent implements OnInit {
  form : Empolyee = {
    updatedBy : '',
    updatedDate : new Date(),
    id : 0,
    address : '' ,
    age : 0 ,
    birthDate : new Date() ,
    createdBy : '' ,
    creationDate : new Date(),
    deletedBy : '' ,
    deletionDate : new Date(),
    email : '',
    experienceYear : 0,
    firstName : '',
    gender : 0 ,
    hiringDate : new Date(),
    isDeleted : false ,
    lastName : '' ,
    maritalStatus : 0,
    militaryStatus : 0 ,
    mobilePhone : '',
    position : ''
  };
  public gender : any = {
    1 : "Male",
    2 : "Female"
   }
   public MaritalStatus : any =
   {
      1 : "Single",
      2 : "Married" ,
      3 : "Other"
   }

   public MilitaryStatus : any = {
     1 : "Compeleted" ,
     2 : "Not Compeleted"
   }
  constructor(private service : EmpolyeeService , private router : Router , private snackBar : MatSnackBar) {

  }

  ngOnInit(): void {
  }

  selectGender(event : any)
  {
    console.log(event)
    this.form.gender = Number.parseInt(event.value);
  }
  selectmatiral(event : any)
  {
    this.form.maritalStatus = Number.parseInt(event.value);
  }
  selectmilitary(event : any)
  {
    this.form.militaryStatus = Number.parseInt(event.value);
  }
  save()
  {
    this.service.AddNewEmpolyee(this.form).subscribe(
      (res)=> {
          this.snackBar.open('Added Sucessfully' , '' , {
            duration:3000
          });
          this.router.navigate(['/Dashboard']);
      }
    )

  }
}
