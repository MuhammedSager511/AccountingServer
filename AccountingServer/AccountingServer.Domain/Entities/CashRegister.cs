using AccountingServer.Domain.Abstractions;
using AccountingServer.Domain.Enums;

namespace AccountingServer.Domain.Entities;
public sealed class CashRegister : Entity
{
    public string Name { get; set; } = string.Empty;
    public CurrencyTypeEnum CurrencyType { get; set; } = CurrencyTypeEnum.USD;
    public decimal DepositAmount { get; set; } //ادخال مبلغ
    public decimal WithdrawalAmount { get; set; } //خروج المبلغ
    public decimal BalanceAmount { get; set; } //باقي من المبلغ
    //public List<CashRegisterDetail>? Details { get; set; }
}
