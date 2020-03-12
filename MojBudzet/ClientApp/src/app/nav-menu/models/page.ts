import { Type } from "@angular/compiler/src/core";

export class Page {
  path: string;
  component: Type;
  title: string;
  isDefault: boolean = false
}
