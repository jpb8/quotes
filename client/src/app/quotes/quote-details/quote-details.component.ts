import { Component, OnInit } from '@angular/core';
import { IProject } from 'src/app/shared/models/project';
import { QuotesService } from '../quotes.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-quote-details',
  templateUrl: './quote-details.component.html',
  styleUrls: ['./quote-details.component.scss']
})
export class QuoteDetailsComponent implements OnInit {
  project: IProject;

  constructor(private quoteService: QuotesService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
  }

  loadProject() {
    this.quoteService.getProject(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(project => {
      this.project = project;
    }, error => {
      console.log(error);
    });
  }

}
