import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SearchParameters } from '../../entity/SearchParameters';

@Injectable()
export class SearchService {

  constructor(private http: HttpClient) { }

  private url = "api/request";

  GetRequestValue(searchParameters: SearchParameters) {
    return this.http.post(this.url, searchParameters);
  }
}
