import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MonthlyBudgetComponent } from './monthly-budget.component';
import { CreateComponent } from './components/create/create.component';
import { monthlyBudgetRoutesNames } from './monthly-budget-routes-names'

const routes: Routes = [
  { path: '', component: MonthlyBudgetComponent },
  { path: monthlyBudgetRoutesNames.CREATE, component: CreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonthlyBudgetRoutingModule { }
