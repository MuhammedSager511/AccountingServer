using Ardalis.SmartEnum;

namespace AccountingServer.Domain.Enums;
public sealed class CustomerTypeEnum : SmartEnum<CustomerTypeEnum>
{
    public static readonly CustomerTypeEnum Alicilar = new("Commercial Buyers", 1);
    public static readonly CustomerTypeEnum Saticilar = new("Commercial Sellers", 2);
    public static readonly CustomerTypeEnum Personel = new("Personnel", 3);
    public static readonly CustomerTypeEnum Ortaklar = new("Company Partners", 4);

    public CustomerTypeEnum(string name, int value) : base(name, value)
    {
    }
}
