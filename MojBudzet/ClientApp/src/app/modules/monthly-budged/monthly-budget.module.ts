import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { MonthlyBudgetRoutingModule } from './monthly-budget-routing.module';
import { MonthlyBudgetComponent } from './monthly-budget.component';
import { CreateComponent } from './components/create/create.component';

@NgModule({
  declarations: [MonthlyBudgetComponent, CreateComponent],
  imports: [
    CommonModule,
    MonthlyBudgetRoutingModule
  ]
})
export class MonthlyBudgetModule { }
