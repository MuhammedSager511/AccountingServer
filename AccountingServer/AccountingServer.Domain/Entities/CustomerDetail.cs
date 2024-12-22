using AccountingServer.Domain.Abstractions;
using AccountingServer.Domain.Enums;

namespace AccountingServer.Domain.Entities;
public sealed class CustomerDetail : Entity
{
    public Guid CustomerId { get; set; }
    public DateOnly Date { get; set; }
    public CustomerDetailTypeEnum Type { get; set; } = CustomerDetailTypeEnum.CashRegister;
    public string Description { get; set; } = string.Empty;
    public decimal DepositAmount { get; set; } 
    public decimal WithdrawalAmount { get; set; } 
    public Guid? BankDetailId { get; set; }
    public Guid? CashRegisterDetailId { get; set; }
    public Guid? InvoiceId { get; set; }
}
