import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchReqest } from 'src/app/entity/SearchReqest';
import { RootObject } from '../../entity/reqest/RootObject';

@Injectable({
  providedIn: 'root'
})

export class SearchReqestService {
  constructor(private http: HttpClient) { }

  private url = "api/searchrequest";

  Insert(rootObject: RootObject) {
    return this.http.post(this.url, rootObject);
  }

  GetAll() {
    return this.http.get<Array<SearchReqest>>(this.url);
  }
}
