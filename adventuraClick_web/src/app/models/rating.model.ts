import { Travel } from "./travel.model";
import { User } from "./user.model";

export interface Rating{
    ratingId?: number;
    rate?: number;
    comment?: string;
    travel?: Travel;
    user?: User;
}