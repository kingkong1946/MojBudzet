import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MonthlyBudget } from './components/create/monthly-budget';

@Injectable({
  providedIn: 'root'
})
export class MonthlyBudgetService {
  private readonly BASE_URL = 'api/MonthlyBudget';
  constructor(
    private httpClient: HttpClient
  ) { }

  create(model: MonthlyBudget): Observable<any> {
    return this.httpClient.post(this.BASE_URL, {month: model.month});
  }
}
