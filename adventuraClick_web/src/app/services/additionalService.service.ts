import { HttpClient } from "@angular/common/http";
import { BaseService } from "./base.service";
import { Injectable } from "@angular/core";
import { AdditionalService } from "../models/additionalService.model";

@Injectable({
    providedIn: 'root',
  })
  export class AdditionalServices extends BaseService<AdditionalService> {
    constructor(protected override http: HttpClient) {
      super(http, 'additionalService');
    }
  }