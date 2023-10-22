import { Payment } from "./payment.model";
import { Travel } from "./travel.model";

export class Reservation{
    reservationId?: number;
    date?: Date;
    numberOfPassangers?: number;
    travel?: Travel;
    payment?: Payment;
}