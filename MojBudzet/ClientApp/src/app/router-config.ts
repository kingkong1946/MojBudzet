import { Routes } from "@angular/router";
import { pagesConfig } from "./nav-menu/models/router-config";

export const routerConfig: Routes = pagesConfig.map((entry: any) => {
  return {
    path: entry.path,
    component: entry.component
  };
}).concat([
  {
    path: '',
    component: pagesConfig.find((entry) => { return entry.isDefault }).component,
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: '/' + pagesConfig.find((entry) => { return entry.isDefault }).path,
    pathMatch: 'full'
  }]);
