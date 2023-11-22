import { TestBed } from '@angular/core/testing';

import { SearchReqestService } from './search-reqest.service';

describe('SearchReqestService', () => {
  let service: SearchReqestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchReqestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
