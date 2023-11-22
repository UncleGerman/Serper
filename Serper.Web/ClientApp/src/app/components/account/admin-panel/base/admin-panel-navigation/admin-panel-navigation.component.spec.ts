import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPanelNavigationComponent } from './admin-panel-navigation.component';

describe('AdminPanelNavigationComponent', () => {
  let component: AdminPanelNavigationComponent;
  let fixture: ComponentFixture<AdminPanelNavigationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminPanelNavigationComponent]
    });
    fixture = TestBed.createComponent(AdminPanelNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
