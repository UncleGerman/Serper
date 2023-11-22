import { TestBed } from '@angular/core/testing';

import { AuntificationService } from './auntification.service';

describe('AuntificationService', () => {
  let service: AuntificationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuntificationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
