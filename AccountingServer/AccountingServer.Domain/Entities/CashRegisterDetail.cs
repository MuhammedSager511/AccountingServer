using AccountingServer.Domain.Abstractions;

namespace AccountingServer.Domain.Entities;
public sealed class CashRegisterDetail : Entity
{
    public Guid CashRegisterId { get; set; }    
    public DateOnly Date {  get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal DepositAmount { get; set; } //ادخال المبلغ
    public decimal WithdrawalAmount { get; set; } //خروج المبلغ//out
    public Guid? CashRegisterDetailId { get; set; }    
    public Guid? BankDetailId { get; set; }    
    public Guid? CustomerDetailId { get; set; }    
}
