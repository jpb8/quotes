import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuotesComponent } from './quotes.component';
import { CoreModule } from '../core/core.module';
import { ProjectItemComponent } from './project-item/project-item.component';


@NgModule({
  declarations: [QuotesComponent, ProjectItemComponent],
  imports: [
    CommonModule,
    CoreModule
  ],
  exports: [QuotesComponent]
})
export class QuotesModule { }
