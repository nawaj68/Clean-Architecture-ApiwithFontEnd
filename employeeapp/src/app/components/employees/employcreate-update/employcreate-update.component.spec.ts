import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmploycreateUpdateComponent } from './employcreate-update.component';

describe('EmploycreateUpdateComponent', () => {
  let component: EmploycreateUpdateComponent;
  let fixture: ComponentFixture<EmploycreateUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmploycreateUpdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmploycreateUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
