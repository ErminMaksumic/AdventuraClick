import { TravelInformation } from "../models/travel-information.model";

export const displayDates = (data: TravelInformation[]) => {
    return data
      .map((item) => {
        let date = new Date(item.departureTime!);
        let year = date.getFullYear();
        let month = String(date.getMonth() + 1).padStart(2, '0');
        let day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
      })
      .join(', ');
  }