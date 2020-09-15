import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IFeatureInProg, IQuoteInProg, IUserStoryInProg } from '../shared/models/builder';
import { BuilderService } from './builder.service';

@Component({
  selector: 'app-builder',
  templateUrl: './builder.component.html',
  styleUrls: ['./builder.component.scss']
})
export class BuilderComponent implements OnInit {
  builder$: Observable<IQuoteInProg>;

  constructor(private builderServce: BuilderService, private router: Router) { }

  ngOnInit(): void {
    this.builder$ = this.builderServce.builder$;
  }

  deleteBuilder(builderId: string): void {
    this.builderServce.deleteBuilder(builderId);
    this.router.navigate(['/quotes']);
  }

  deleteFeature(feature: IFeatureInProg): void {
    this.builderServce.deleteFeatureFromBuilder(feature);
  }

  deleteUserStory(feature: IFeatureInProg, userStory: IUserStoryInProg): void {
    this.builderServce.deleteStoryFromFeature(feature, userStory);
  }

  // addUserStory(featureId: number, storyData: any): void {

  // }

}
