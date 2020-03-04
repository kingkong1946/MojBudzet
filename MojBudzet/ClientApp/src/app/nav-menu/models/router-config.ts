import { Routes } from "@angular/router";
import { FetchDataComponent } from "../../fetch-data/fetch-data.component";

export const pagesConfig = [
  { path: 'fetch', component: FetchDataComponent, title: 'Fetch', isDefault: true }
]

export function getRouterConfig(): Routes {
  let result: Routes = [];

  pagesConfig.map((entry: any) => {
    result.push({ path: entry.path, component: entry.component });
    if (entry.isDefault) {
      result.push({ path: '', component: entry.component, pathMatch: 'full' });
      result.push({ path: '**', redirectTo: '/' + entry.path, pathMatch: 'full' });
    }
  });

  return result;
}
