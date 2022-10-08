
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatTabsModule} from '@angular/material/tabs';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from "@angular/common/http";
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatMenuModule} from '@angular/material/menu';
import {MatBadgeModule} from '@angular/material/badge';
import {MatListModule} from '@angular/material/list';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDialogModule} from '@angular/material/dialog';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatRadioModule} from '@angular/material/radio';
import { LoginComponent } from './Components/login/login.component';
import { AuthGuard } from './Helpers/AuthGuard';
import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { EmpolyeeDetailsComponent } from './Pages/empolyee-details/empolyee-details.component';
import { AddEmpolyeeComponent } from './Components/add-empolyee/add-empolyee.component';
import { EditEmpolyeeComponent } from './Pages/edit-empolyee/edit-empolyee.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    EmpolyeeDetailsComponent,
    AddEmpolyeeComponent,
    EditEmpolyeeComponent,

 ],
  imports: [
    BrowserModule,
    MatNativeDateModule ,
    MatDatepickerModule,
    MatSidenavModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatIconModule,
    FlexLayoutModule,
    MatCheckboxModule,
    MatTableModule,
    MatListModule,
    MatMenuModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatToolbarModule,
    MatBadgeModule,
    MatTabsModule,
    MatCardModule,
    MatDialogModule,
    MatPaginatorModule,
    MatFormFieldModule,
    PerfectScrollbarModule,
    MatRadioModule,
    FormsModule,
    MatButtonModule,
    MatInputModule

  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule,
    AuthGuard ,
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

// required for AOT compilation
export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}
