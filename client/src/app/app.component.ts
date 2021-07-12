import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BuilderService } from './builder/builder.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'quotes';

  constructor(private builderService: BuilderService, private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadBuilder();
    this.loadCurrentUser();
  }

  loadBuilder(): void {
    const builderId = localStorage.getItem('builder_id');
    this.builderService.getBuilder(builderId).subscribe(() => {
      console.log('Retreaved Builder');
    }, error => {
      console.log(error);
    });
  }

  loadCurrentUser(): void {
    const token = localStorage.getItem('token');
    if (token) {
      this.accountService.loadCurrentUser(token).subscribe(() => {
        console.log('User Loaded From App');
      }, error => {
        console.log(error);
      });
    }
  }

}
export class NgbdCollapseBasic {
  public isCollapsed = false;
}
