import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { IQuoteInProg, IFeatureInProg, IUserStoryInProg, QuoteInProg } from './../shared/models/builder';
import { IFeature, IUserStory } from './../shared/models/project';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BuilderService {
  baseUrl = environment.apiUrl;
  private builderSource = new BehaviorSubject<IQuoteInProg>(null);
  builder$ = this.builderSource.asObservable();

  constructor(private http: HttpClient) { }

  getBuilder(id: string): any {
    return this.http.get(this.baseUrl + '/QuoteInProg?id=' + id).pipe(
      map((quote: IQuoteInProg) => {
        this.builderSource.next(quote);
        console.log(this.getCurrentBuilderValue());
      })
    );
  }

  setBuilder(quote: IQuoteInProg): any {
    return this.http.post(this.baseUrl + '/QuoteInProg', quote).subscribe((response: IQuoteInProg) => {
      this.builderSource.next(response);
    }, error => {
      console.log(error);
    });
  }

  deleteBuilder(id: string): any {
    return this.http.delete(this.baseUrl + '/QuoteInProg?id=' + id).subscribe(response => {
      this.builderSource.next(null);
      localStorage.removeItem('builder_id');
    }, error => {
      console.log(error);
    });
  }

  getCurrentBuilderValue(): any {
    return this.builderSource.value;
  }

  addFeatureToBuilder(feature: IFeature): void {
    const featureToAdd: IFeatureInProg = this.mapFeatureToInProg(feature);
    const builder = this.getCurrentBuilderValue() ?? this.createBuilder();
    builder.features.push(featureToAdd);
    this.setBuilder(builder);
  }

  addUserStoryToFeature(featureId: number, userStory: IUserStoryInProg): void {
    const builder = this.getCurrentBuilderValue();
    const featureIndex = builder.features.findIndex(x => x.id === featureId);
    builder.features[featureIndex].userStories.push(userStory);
    builder.features[featureIndex].discoveryTotal += userStory.discovery;
    builder.features[featureIndex].designTotal += userStory.design;
    builder.features[featureIndex].implementationTotal += userStory.implementation;
    builder.features[featureIndex].testTotal += userStory.test;
    this.setBuilder(builder);
  }

  deleteFeatureFromBuilder(feature: IFeatureInProg): void {
    const builder = this.getCurrentBuilderValue();
    if (builder.features.some(x => x.id === feature.id)) {
      builder.features = builder.features.filter(i => i.id !== feature.id);
      if (builder.features.length > 0) {
        this.setBuilder(builder);
      } else {
        this.deleteBuilder(builder.id);
      }
    }
  }

  deleteStoryFromFeature(feature: IFeatureInProg, userStory: IUserStoryInProg): void {
    const builder = this.getCurrentBuilderValue();
    const featureIndex = builder.features.findIndex(x => x.id === feature.id);
    if (builder.features[featureIndex].userStories.some(x => x.id === userStory.id)) {
      builder.features[featureIndex].userStories = builder.features[featureIndex].userStories.filter(i => i.id !== userStory.id);
      builder.features[featureIndex].discoveryTotal -= userStory.discovery;
      builder.features[featureIndex].designTotal -= userStory.design;
      builder.features[featureIndex].implementationTotal -= userStory.implementation;
      builder.features[featureIndex].testTotal -= userStory.test;
      this.setBuilder(builder);
    }
  }

  private createBuilder(): IQuoteInProg {
    const builder = new QuoteInProg();
    localStorage.setItem('builder_id', builder.id);
    return builder;
  }

  private buildUserStoriesAndTotals(userStories: IUserStory[]): any {
    let discoveryTotal = 0;
    let designTotal = 0;
    let implementationTotal = 0;
    let testTotal = 0;
    const userStoriesInProg = [];
    userStories.forEach(x => {
      userStoriesInProg.push({
        id: x.id,
        description: x.description,
        division: x.division,
        serviceDiscipline: x.serviceDiscipline,
        discovery: x.discovery,
        design: x.design,
        implementation: x.implementation,
        test: x.test,
        resourceType: x.resourceType.name
      });
      discoveryTotal += x.discovery;
      designTotal += x.design;
      implementationTotal += x.implementation;
      testTotal += x.test;
    });
    return {
      userStoriesInProg,
      discoveryTotal,
      designTotal,
      implementationTotal,
      testTotal
    };
  }

  private mapFeatureToInProg(feature: IFeature): IFeatureInProg {
    const userStoryData = this.buildUserStoriesAndTotals(feature.userStories);
    return {
      id: feature.id,
      description: feature.description,
      mileStone: feature.mileStone,
      discoveryTotal: userStoryData.discoveryTotal,
      designTotal: userStoryData.designTotal,
      implementationTotal: userStoryData.implementationTotal,
      testTotal: userStoryData.testTotal,
      userStories: userStoryData.userStoriesInProg
    };
  }
}
