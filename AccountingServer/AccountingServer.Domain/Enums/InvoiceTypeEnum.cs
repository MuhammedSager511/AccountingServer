using Ardalis.SmartEnum;

namespace AccountingServer.Domain.Enums;
public sealed class InvoiceTypeEnum : SmartEnum<InvoiceTypeEnum>
{
    public static readonly InvoiceTypeEnum Purchase = new("Purchase Invoice", 1);
    public static readonly InvoiceTypeEnum Selling = new("Selling Invoice", 2);

    public InvoiceTypeEnum(string name, int value) : base(name, value)
    {
    }
}
