import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SearchParameters } from '../../../entity/SearchParameters';
import { SearchService } from '../../../service/search.service';
import { RootObject } from '../../../entity/RootObject';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {
  constructor(private searchService: SearchService) { }

  ngOnInit() {
    this.searchForm = new FormGroup({
      type: new FormControl(""),
      query: new FormControl(""),
      country: new FormControl(""),
      locale: new FormControl(""),
      autocorrect: new FormControl(""),
      page: new FormControl("")
    });
  }

  public searchForm!: FormGroup;

  public rootObject: RootObject = new RootObject();

  public GetRequestValue(searchForm: FormGroup) {
    let searchParameters: SearchParameters = {
      q: searchForm.value.query,
      gl: searchForm.value.country,
      hl: searchForm.value.locale,
      autocorrect: searchForm.value.autocorrect,
      page: searchForm.value.page,
      type: searchForm.value.type
    };

    this.searchService.GetRequestValue(searchParameters)
      .subscribe((data: RootObject) => {
        this.rootObject = data
      });
  }
}
