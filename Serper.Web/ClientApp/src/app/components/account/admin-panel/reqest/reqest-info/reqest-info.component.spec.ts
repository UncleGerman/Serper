import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReqestInfoComponent } from './reqest-info.component';

describe('ReqestInfoComponent', () => {
  let component: ReqestInfoComponent;
  let fixture: ComponentFixture<ReqestInfoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReqestInfoComponent]
    });
    fixture = TestBed.createComponent(ReqestInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
