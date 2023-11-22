import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleInsertComponent } from './role-insert.component';

describe('RoleInsertComponent', () => {
  let component: RoleInsertComponent;
  let fixture: ComponentFixture<RoleInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoleInsertComponent]
    });
    fixture = TestBed.createComponent(RoleInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
