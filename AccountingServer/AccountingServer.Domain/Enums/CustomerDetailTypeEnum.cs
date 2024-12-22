using Ardalis.SmartEnum;

namespace AccountingServer.Domain.Enums;
public sealed class CustomerDetailTypeEnum : SmartEnum<CustomerDetailTypeEnum>
{
    public static readonly CustomerDetailTypeEnum Bank = new("Bank", 1);
    public static readonly CustomerDetailTypeEnum CashRegister = new("Cash Register", 2);
    public static readonly CustomerDetailTypeEnum PurchaseInvoice = new("Purchase Invoice", 3);
    public static readonly CustomerDetailTypeEnum SellingInvoice = new("Selling Invoice", 4);

    public CustomerDetailTypeEnum(string name, int value) : base(name, value)
    {
    }
}
