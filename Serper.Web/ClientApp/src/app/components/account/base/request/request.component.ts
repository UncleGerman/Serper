import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { RootObject } from '../../../../entity/reqest/RootObject';
import { Organic } from 'src/app/entity/reqest/Organic';
import { SearchParameters } from '../../../../entity/SearchParameters';

import { SearchService } from '../../../../service/search/search.service';
import { SearchReqestService } from '../../../../service/search-reqest/search-reqest.service';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.scss'],
  providers: [
    SearchService,
    SearchReqestService
  ]
})

export class RequestComponent {
  constructor(
    private _searchService: SearchService,
    private _searchReqestService: SearchReqestService) { }

  ngOnInit() {
    this.SearchForm = new FormGroup({
      type: new FormControl("", Validators.required),
      query: new FormControl("", 
      [
        Validators.required,
        Validators.minLength(5)
      ]),
      country: new FormControl("", Validators.required),
      locale: new FormControl("", Validators.required),
      autocorrect: new FormControl("", Validators.required),
      page: new FormControl("", Validators.required)
    });
  }

  public SearchForm!: FormGroup;

  public RootObject: RootObject = new RootObject();

  public Organics: Array<Organic> = new Array<Organic>();

  public GetRequestValue(SearchForm: FormGroup) {
    let searchParameters: SearchParameters = {
      q: SearchForm.value.query,
      gl: SearchForm.value.country,
      hl: SearchForm.value.locale,
      autocorrect: SearchForm.value.autocorrect,
      page: SearchForm.value.page,
      type: SearchForm.value.type
    };

    this._searchService.GetRequestValue(searchParameters)
      .subscribe((data: RootObject) => {
        this.RootObject = data
        this.Organics = data.organic
      });

    this._searchReqestService.Insert(this.RootObject);
  }
}
