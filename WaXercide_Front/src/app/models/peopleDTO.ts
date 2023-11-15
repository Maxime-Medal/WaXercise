import { Compagny } from "./compagny";

export interface PeopleDTO {
    id: number;
    firstName: string;
    lastName: string;
    Age: number;
    compagnies?: Compagny[];
}