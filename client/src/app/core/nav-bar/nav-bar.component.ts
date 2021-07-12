import { Component, OnInit } from '@angular/core';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BuilderService } from 'src/app/builder/builder.service';
import { IQuoteInProg } from 'src/app/shared/models/builder';
import { IUser } from 'src/app/shared/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }]
})
export class NavBarComponent implements OnInit {
  builder$: Observable<IQuoteInProg>;
  currentUser$: Observable<IUser>;

  constructor(private builderService: BuilderService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.builder$ = this.builderService.builder$;
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout(): void {
    this.accountService.logout();
  }

}
