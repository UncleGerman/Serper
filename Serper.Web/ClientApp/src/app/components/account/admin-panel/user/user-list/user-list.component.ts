import { Component } from '@angular/core';
import { User } from 'src/app/entity/user/User';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  providers: [UserService]
})
export class UserListComponent {
  ngOnInit() {
    this.LoadUsers();
  }

  constructor(private userService: UserService) {}

  public users: Array<User> = new Array <User>();

  private LoadUsers() {
    this.userService.GetAll()
      .subscribe((data: Array<User>) => { this.users = data });
  }
}
