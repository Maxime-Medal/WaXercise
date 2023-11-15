import { Compagny } from "./compagny";

export interface People {
    id?: number;
    firstName: string;
    lastName: string;
    birthDate: Date | string;
    compagnies?: Compagny[];

}