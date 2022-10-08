import { DashboardComponent } from './../../Components/dashboard/dashboard.component';
import { Empolyee } from './../../Model/Request/Empolyee';
import { EmpolyeeService } from './../../Services/empolyee.service';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-empolyee-details',
  templateUrl: './empolyee-details.component.html',
  styleUrls: ['./empolyee-details.component.scss']
})
export class EmpolyeeDetailsComponent implements OnInit {
  protected data : Empolyee;
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
    private service : EmpolyeeService) {
      this.dialogRef.disableClose = true;
     }

  ngOnInit(): void {
    this.service.getEmpolyeeById(this.id).subscribe(
      (res)=> this.data = res ,
      (err)=> console.log(err)
    )
  }

}
