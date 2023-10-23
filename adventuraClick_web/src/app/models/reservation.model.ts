import { AdditionalService } from "./additionalService.model";
import { Payment } from "./payment.model";
import { Travel } from "./travel.model";
import { User } from "./user.model";

export class Reservation{
    reservationId?: number;
    date?: Date;
    numberOfPassangers?: number;
    user?: User;
    travel?: Travel;
    payment?: Payment;
    additionalServices?: AdditionalService[];
}