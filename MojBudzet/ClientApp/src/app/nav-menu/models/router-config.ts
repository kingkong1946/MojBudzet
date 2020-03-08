import { Routes } from "@angular/router";
import { FetchDataComponent } from "../../fetch-data/fetch-data.component";

export const pagesConfig = [
  { path: 'fetch', component: FetchDataComponent, title: 'Fetch', isDefault: true }
]
