export class CurrencyTypeModel{
    name: string = "";
    value: number = 1;
}

export const CurrencyTypes: CurrencyTypeModel[] = [
    {
        name: "USD",
        value: 1
    },
    {
        name: "TL",
        value: 2
    },
    {
        name: "EUR",
        value: 3
    }
]