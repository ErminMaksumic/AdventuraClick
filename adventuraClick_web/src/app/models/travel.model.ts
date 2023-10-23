import { IncludedItem } from "./included-item.model";
import { TravelInformation } from "./travel-information.model";
import { TravelType } from "./travel-type.model";

export interface Travel {
  travelId?: number;
  date?: Date;
  description?: string;
  image?: string;
  name?: string;
  numberOfNights?: string;
  price?: number;
  travelType?: TravelType
  travelInformations?: TravelInformation[];
  includedItems?: IncludedItem[];
}
