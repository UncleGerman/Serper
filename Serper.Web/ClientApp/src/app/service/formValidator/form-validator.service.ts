import { FormGroup } from '@angular/forms';

export class FormValidatorService {
  public GetPasswordErrors(formGroup: FormGroup) {
    if (formGroup.controls['password'].hasError('pattern')) {
      return 'The password must contain at least one number, one uppercase character, and one lowercase character.';
    }

    if (formGroup.controls['password'].hasError('minlength')) {
      return 'Password must consist of at least 8 characters.';
    }

    return formGroup.controls['password'].hasError('required') ? 'Password is required.' : '';
  }

  public GetEmailErrors(formGroup: FormGroup) {
    if (formGroup.controls['email'].hasError('required')) {
      return 'Field must be filled in.';
    }

    return formGroup.controls['email'].hasError('email') ? 'Email is required.' : '';
  }
}