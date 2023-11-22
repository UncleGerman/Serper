import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/entity/user/User';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss']
})
export class UserEditComponent {
  constructor(
    private userService: UserService,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    const id = Number(this.activeRoute.snapshot.paramMap.get('id'));

    this.UserForm = new FormGroup({
      Name: new FormControl(""),
      Email: new FormControl(""),
      Role: new FormControl(""),
      Password: new FormControl("")
    });
  }

  public UserForm!: FormGroup;

  public UpdateUser(UserForm: FormGroup) {
    let user: User = {
      userName: this.UserForm.value.Name,
      email: this.UserForm.value.Email,
      password: this.UserForm.value.Password,
      roleName: this.UserForm.value.Role
    };
  }

  private GetUser() {

  }
}
