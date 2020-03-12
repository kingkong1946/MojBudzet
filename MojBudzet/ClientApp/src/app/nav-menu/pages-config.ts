import { FetchDataComponent } from "../fetch-data/fetch-data.component";
import { Page } from "./models/page";

export const pagesConfig: Page[] = [
  { path: 'fetch', component: FetchDataComponent, title: 'Fetch', isDefault: true }
]
