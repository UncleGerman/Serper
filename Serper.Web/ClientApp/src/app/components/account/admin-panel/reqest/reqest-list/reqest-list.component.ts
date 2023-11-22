import { Component } from '@angular/core';

import { SearchReqest } from 'src/app/entity/SearchReqest';
import { SearchReqestService } from 'src/app/service/search-reqest/search-reqest.service';
import { SearchService } from 'src/app/service/search/search.service';

@Component({
  selector: 'app-reqest-list',
  templateUrl: './reqest-list.component.html',
  styleUrls: ['./reqest-list.component.scss'],
  providers: [SearchService]
})
export class ReqestListComponent {
  constructor(private searchReqestService: SearchReqestService) {}

  ngOnInit() {
    this.GetAll();
  }

  public searchReqests: Array<SearchReqest>;

  private GetAll()
  {
    this.searchReqestService.GetAll()
      .subscribe((data: Array<SearchReqest>) => this.searchReqests = data);
  }
}