import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BuilderService } from 'src/app/builder/builder.service';
import { IQuoteInProg } from 'src/app/shared/models/builder';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  builder$: Observable<IQuoteInProg>;

  constructor(private builderService: BuilderService) { }

  ngOnInit(): void {
    this.builder$ = this.builderService.builder$;
  }

}
