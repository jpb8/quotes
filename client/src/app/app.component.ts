import { Component, OnInit } from '@angular/core';
import { BuilderService } from './builder/builder.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'quotes';

  constructor(private builderService: BuilderService) {}

  ngOnInit(): void {
    const builderId = localStorage.getItem('builder_id');
    if (builderId) {
      this.builderService.getBuilder(builderId).subscribe(() => {
        console.log('Retreaved Builder');
      }, error => {
        console.log(error);
      });
    }
  }

}
export class NgbdCollapseBasic {
  public isCollapsed = false;
}
