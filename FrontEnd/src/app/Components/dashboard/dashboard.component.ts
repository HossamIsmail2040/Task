import { MatSnackBar } from '@angular/material/snack-bar';
import { EditEmpolyeeComponent } from './../../Pages/edit-empolyee/edit-empolyee.component';
import { EmpolyeeDetailsComponent } from './../../Pages/empolyee-details/empolyee-details.component';
import { Empolyee } from './../../Model/Request/Empolyee';
import { EmpolyeeService } from './../../Services/empolyee.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

   data : Empolyee[] = [];
  constructor(private service : EmpolyeeService ,
     private dailog : MatDialog , private router : Router ,
     private snackBar : MatSnackBar) {
      this.initateData();
     }

  ngOnInit(): void {
    this.initateData();

  }

  initateData()
  {
    this.service.getAllEmpolyee()
    .subscribe(
     (res)=> {
       this.data =res

     },
     (err)=> console.log(err)
    )
  }

  details(id : number)
  {
     this.dailog.open(EmpolyeeDetailsComponent , {
      width : '75%',
      height : '95%',
      data : id
     })
  }

  Update(id : number)
  {
     const ref = this.dailog.open(EditEmpolyeeComponent , {
      width : '75%',
      height : '95%',
      data : id
     }).afterClosed().subscribe(
      (res)=> { this.initateData()}
     )
  }

  Delete(id : number)
  {
     this.service.DeleteEmpolyee(id).subscribe(
      (res)=> {
         this.snackBar.open('Deleted Sucessfully' , '' , {
          duration : 3000
         });

         this.initateData();
      } ,
      (err)=>console.log(err)
     )
  }
  logout()
  {
    sessionStorage.clear();
    this.router.navigate(['/Login']);
  }
}
