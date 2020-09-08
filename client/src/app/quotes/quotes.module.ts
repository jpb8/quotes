import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuotesComponent } from './quotes.component';
import { ProjectItemComponent } from './project-item/project-item.component';
import { QuoteDetailsComponent } from './quote-details/quote-details.component';
import { QuotesRoutingModule } from './quotes-routing.module';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [QuotesComponent, ProjectItemComponent, QuoteDetailsComponent],
  imports: [
    CommonModule,
    SharedModule,
    QuotesRoutingModule,
  ]
})
export class QuotesModule { }
