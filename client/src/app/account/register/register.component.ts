import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { map, repeat, switchMap } from 'rxjs/operators';
import { IOffice } from 'src/app/shared/models/office';
import { IRegister } from 'src/app/shared/models/user';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  offices: IOffice[];
  registerForm: FormGroup;
  errors: string[];

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.getOfficeList();
    this.createRegisterForm();
  }

  createRegisterForm(): void {
    this.registerForm = new FormGroup({
      displayName: new FormControl(null, Validators.required),
      email: new FormControl(
        null,
        [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
        [this.validateEmailNotTaken()]
      ),
      password: new FormControl(null, Validators.required),
      passwordRepet: new FormControl(null, Validators.required),
      office: new FormControl(1, Validators.required)
    });
  }

  getOfficeList(): void {
    this.accountService.getOfficesList().subscribe(response => {
      this.offices = response;
    }, error => {
      console.log(error);
    });
  }

  onSubmit(): void {
    if (this.registerForm.value.password === this.registerForm.value.passwordRepet) {
      const register: IRegister = {
        displayName: this.registerForm.value.displayName,
        email: this.registerForm.value.email,
        password: this.registerForm.value.password,
        officeId: this.registerForm.value.office
      };
      this.accountService.register(register).subscribe(response => {
        this.router.navigateByUrl('/quotes');
      }, error => {
        console.log(error);
        this.errors = error.errors;
      });
    } else {
      console.log('Password did not match');
    }
  }

  validateEmailNotTaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map(res => {
              return res ? {emailExists: true} : null;
            })
          );
        })
      );
    };
  }

}
