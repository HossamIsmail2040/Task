import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmpolyeeComponent } from './add-empolyee.component';

describe('AddEmpolyeeComponent', () => {
  let component: AddEmpolyeeComponent;
  let fixture: ComponentFixture<AddEmpolyeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmpolyeeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEmpolyeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
