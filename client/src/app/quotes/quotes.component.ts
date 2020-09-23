import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IProject, IProjectListItem } from '../shared/models/project';
import { QuotesService } from './quotes.service';

@Component({
  selector: 'app-quotes',
  templateUrl: './quotes.component.html',
  styleUrls: ['./quotes.component.scss']
})
export class QuotesComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  projects: IProject[];
  projectList: IProjectListItem[];
  projectIdSelected: number;
  projectSearch: string;
  selectedProject: IProject;

  constructor(private quotesService: QuotesService) { }

  ngOnInit(): void {
    this.getProjects();
    this.getProjectList();
  }

  getProjects(): void {
    this.quotesService.getProjects().subscribe(response => {
      this.projects = response;
    }, error => {
      console.log(error);
    });
  }

  getProjectList(search?: string): void {
    this.quotesService.getProjectList(search).subscribe(response => {
      this.projectList = response;
    }, error => {
      console.log(error);
    });
  }

  getProject(): void {
    this.quotesService.getProject(this.projectIdSelected).subscribe(response => {
      this.selectedProject = response;
    }, error => {
      console.log(error);
    });
  }

  onProjectSelected(projectId: number): void {
    this.projectIdSelected = projectId;
    this.getProject();
  }

  onProjectListSearch(): void {
    this.projectSearch = this.searchTerm.nativeElement.value;
    this.getProjectList(this.projectSearch);
  }

  onProjectListReset(): void {
    this.searchTerm.nativeElement.value = '';
    this.projectSearch = undefined;
    this.getProjectList(this.projectSearch);
  }

}
