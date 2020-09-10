import { Component, OnInit } from '@angular/core';
import { IProject } from 'src/app/shared/models/project';
import { QuotesService } from '../quotes.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-quote-details',
  templateUrl: './quote-details.component.html',
  styleUrls: ['./quote-details.component.scss']
})
export class QuoteDetailsComponent implements OnInit {
  project: IProject;

  constructor(
    private quoteService: QuotesService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService
    ) { }

  ngOnInit(): void {
    this.loadProject();
  }

  loadProject() {
    this.quoteService.getProject(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(project => {
      this.project = project;
      this.bcService.set('@quoteDetails', project.name);
    }, error => {
      console.log(error);
    });
  }

}
