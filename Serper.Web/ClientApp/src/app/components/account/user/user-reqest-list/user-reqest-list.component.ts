import { Component } from '@angular/core';
import { SearchReqest } from 'src/app/entity/SearchReqest';

@Component({
  selector: 'app-user-reqest-list',
  templateUrl: './user-reqest-list.component.html',
  styleUrls: ['./user-reqest-list.component.scss']
})
export class UserReqestListComponent {
  public searchReqests: Array<SearchReqest>;
}
