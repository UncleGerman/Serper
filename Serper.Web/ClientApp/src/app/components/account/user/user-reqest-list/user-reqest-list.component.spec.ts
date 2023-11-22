import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserReqestListComponent } from './user-reqest-list.component';

describe('UserReqestListComponent', () => {
  let component: UserReqestListComponent;
  let fixture: ComponentFixture<UserReqestListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserReqestListComponent]
    });
    fixture = TestBed.createComponent(UserReqestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
