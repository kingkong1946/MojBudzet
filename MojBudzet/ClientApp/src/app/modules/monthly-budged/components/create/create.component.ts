import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { MonthlyBudget } from './monthly-budget';
import { MonthlyBudgetService } from '../../monthly-budget.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  bsConfig: Partial<BsDatepickerConfig> = {
    dateInputFormat: 'MM/YY',
    minMode: 'month'
  }

  model: MonthlyBudget = new MonthlyBudget(new Date());

  constructor(
    private monthlyBudgetService: MonthlyBudgetService,
    private localeService: BsLocaleService
  ) { }

  ngOnInit(): void {
    this.localeService.use('pl');
  }

  onSubmit() {
    this.monthlyBudgetService.create(this.model)
      .subscribe(response => console.log(response));
  }

  diag(obj) { return null; }

}
