import { Component, OnInit, Input } from '@angular/core';
import { IFeature, IProject } from 'src/app/shared/models/project';
import { BuilderService } from 'src/app/builder/builder.service';

@Component({
  selector: 'app-project-item',
  templateUrl: './project-item.component.html',
  styleUrls: ['./project-item.component.scss']
})
export class ProjectItemComponent implements OnInit {
  @Input() project: IProject;

  constructor(private builderService: BuilderService) { }

  ngOnInit(): void {
  }

  addFeatureToBuilder(feature: IFeature) {
    this.builderService.addFeatureToBuilder(feature);
  }

}
