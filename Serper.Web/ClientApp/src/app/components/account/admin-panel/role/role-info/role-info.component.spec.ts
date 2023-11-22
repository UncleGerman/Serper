import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleInfoComponent } from './role-info.component';

describe('RoleInfoComponent', () => {
  let component: RoleInfoComponent;
  let fixture: ComponentFixture<RoleInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RoleInfoComponent]
    });
    fixture = TestBed.createComponent(RoleInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
