import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { appRoutesNames } from './app-routes-names'

const routes: Routes = [
  {
    path: appRoutesNames.MONTHLY_BUDGET,
    loadChildren: './modules/monthly-budged/monthly-budget.module#MonthlyBudgetModule'
  }]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
