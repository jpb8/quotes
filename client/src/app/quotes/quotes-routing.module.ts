import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { QuotesComponent } from './quotes.component';
import { QuoteDetailsComponent } from './quote-details/quote-details.component';

const routes: Routes = [
  {path: '', component: QuotesComponent},
  {path: '/:id', component: QuoteDetailsComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class QuotesRoutingModule { }
