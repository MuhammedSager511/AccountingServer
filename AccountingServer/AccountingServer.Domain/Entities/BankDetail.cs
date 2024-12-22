using AccountingServer.Domain.Abstractions;

namespace AccountingServer.Domain.Entities;
public sealed class BankDetail : Entity
{
    public Guid BankId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal DepositAmount { get; set; } //ادخال
    public decimal WithdrawalAmount { get; set; } //اخراج
    public Guid? BankDetailId { get; set; }   
    public Guid? CashRegisterDetailId { get; set; }
    public Guid? CustomerDetailId { get; set; }
}
