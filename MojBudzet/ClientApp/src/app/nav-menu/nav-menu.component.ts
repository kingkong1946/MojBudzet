import { Component } from '@angular/core';
import { pagesConfig } from './pages-config';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  isExpanded = false;
  pagesConfig: Array<any>;

  constructor() {
    this.pagesConfig = pagesConfig
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
