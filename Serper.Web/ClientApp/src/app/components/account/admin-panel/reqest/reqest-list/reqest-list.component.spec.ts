import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReqestListComponent } from './reqest-list.component';

describe('ReqestListComponent', () => {
  let component: ReqestListComponent;
  let fixture: ComponentFixture<ReqestListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReqestListComponent]
    });
    fixture = TestBed.createComponent(ReqestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
