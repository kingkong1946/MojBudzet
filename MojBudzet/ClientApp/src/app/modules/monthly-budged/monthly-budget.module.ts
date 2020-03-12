import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { MonthlyBudgetRoutingModule } from './monthly-budget-routing.module';
import { MonthlyBudgetComponent } from './monthly-budget.component';
import { CreateComponent } from './components/create/create.component';

@NgModule({
  declarations: [MonthlyBudgetComponent, CreateComponent],
  imports: [
    CommonModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    MonthlyBudgetRoutingModule,
  ]
})
export class MonthlyBudgetModule { }
