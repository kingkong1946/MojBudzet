import { Component, OnInit } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { MonthlyBudget } from './monthly-budget';

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

  model: MonthlyBudget = new MonthlyBudget()

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(date) {
    console.log(date);
  }

}
