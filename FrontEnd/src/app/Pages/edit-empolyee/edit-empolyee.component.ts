import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DashboardComponent } from 'src/app/Components/dashboard/dashboard.component';
import { Empolyee } from 'src/app/Model/Request/Empolyee';
import { EmpolyeeService } from 'src/app/Services/empolyee.service';

@Component({
  selector: 'app-edit-empolyee',
  templateUrl: './edit-empolyee.component.html',
  styleUrls: ['./edit-empolyee.component.scss']
})
export class EditEmpolyeeComponent implements OnInit {
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

  gen : string;
  militaryStatus : string;
  maritalStatus : string;
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
  constructor(  public dialogRef: MatDialogRef<DashboardComponent>,
    @Inject(MAT_DIALOG_DATA) public id: number,
    private snackBar : MatSnackBar,
    private service : EmpolyeeService) {
      this.dialogRef.disableClose = true;
     }

  ngOnInit(): void {
    this.service.getEmpolyeeById(this.id).subscribe(
      (res)=>{ this.form = res ,
         this.gen = this.form.gender.toString();
         this.maritalStatus = this.form.maritalStatus.toString();
         this.militaryStatus = this.form.militaryStatus.toString();
      } ,
      (err)=> console.log(err)
    )
  }

  save()
  {
    this.form.gender = Number.parseInt( this.gen)
    this.form.maritalStatus = Number.parseInt(this.maritalStatus);
    this.form.militaryStatus = Number.parseInt(this.militaryStatus);
    this.service.EditEmpolyee(this.form).subscribe(
      (res)=> {
          this.snackBar.open('Updated Sucessfully' , '' , {
            duration:3000
          });
          this.dialogRef.close();
      }
    )
  }
}
