import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppAccountComponent } from './app-account.component';

describe('AppAccountComponent', () => {
  let component: AppAccountComponent;
  let fixture: ComponentFixture<AppAccountComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AppAccountComponent]
    });
    fixture = TestBed.createComponent(AppAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
