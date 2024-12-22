import { CustomerDetailModel } from "./customer-detail.model";

export class CustomerModel{
    id: string = "";
    name: string = "";
    type: CustomerTypeEnum = new CustomerTypeEnum();
    typeValue: number = 1;
    city: string = "";
    town: string  ="";
    fullAddress: string = "";
    taxDepartment: string = "";
    taxNumber: string = "";
    depositAmount: number = 0;
    withdrawalAmount: number = 0;
    details: CustomerDetailModel[] = [];
}

export class CustomerTypeEnum{
    name: string = "";
    value: number = 1;
}

export const CustomerTypes: CustomerTypeEnum[] = [
    {
        name: "Trade Buyers",
        value: 1
        },
        {
        name: "Trade Sellers",
        value: 2
        },
        {
        name: "Staff",
        value: 3
        },
        {
        name: "Partners",
        value: 4
        }
]