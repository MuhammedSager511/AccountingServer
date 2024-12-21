using AccountingServer.Domain.Abstractions;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Enums;

namespace   AccountingServer.Domain.Entities;
public sealed class Bank : Entity
{
    public string Name { get; set; } = string.Empty;
    public string IBAN { get; set; } = string.Empty;
    public CurrencyTypeEnum CurrencyType { get; set; } = CurrencyTypeEnum.TL;
    public decimal DepositAmount { get; set; } //ادخال
    public decimal WithdrawalAmount { get; set; } //اخراج
    public List<BankDetail>? Details { get; set; }
}
