import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserInsertComponent } from './user-insert.component';

describe('UserInsertComponent', () => {
  let component: UserInsertComponent;
  let fixture: ComponentFixture<UserInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserInsertComponent]
    });
    fixture = TestBed.createComponent(UserInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
