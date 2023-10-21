import { HttpClient } from "@angular/common/http";
import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { TravelType } from "../models/travel-type.model";

@Injectable({
    providedIn: 'root',
  })
  export class TravelTypeService extends BaseService<TravelType> {
    constructor(protected override http: HttpClient) {
      super(http, 'travelType');
    }
  }