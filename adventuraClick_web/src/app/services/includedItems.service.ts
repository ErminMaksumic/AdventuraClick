import { HttpClient } from "@angular/common/http";
import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { IncludedItem } from "../models/included-item.model";

@Injectable({
    providedIn: 'root',
  })
  export class IncludedItemService extends BaseService<IncludedItem> {
    constructor(protected override http: HttpClient) {
      super(http, 'includedItem');
    }
  }