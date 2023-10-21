import { HttpClient } from "@angular/common/http";
import { BaseService } from "./base.service";
import { Travel } from "../models/travel.model";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root',
  })
  export class IncludedItemService extends BaseService<Travel> {
    constructor(protected override http: HttpClient) {
      super(http, 'includedItem');
    }
  }