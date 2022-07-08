using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpenseTracking.Models;

public class Expense
{
    [Key]
    public int Id { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    [Required]
    [Display(Name="Expense Date")]
    public DateTime ExpenseDate { get; set; } = DateTime.Now;
    
    [Required]
    [Display(Name="User")]
    public int UserId { get; set; }
    
    [Required]
    [Display(Name="Type")]
    public int ExpenseTypeId { get; set; }
    
    [Required]
    [Display(Name="Currency")]
    public int CurrencyId {get; set;}

    [Required]
    [Range(1.0, 10000.00)]
    [Column(TypeName="money")]
    public decimal Amount { get; set; }

    [ForeignKey("ExpenseTypeId")]
    [ValidateNever]
    public virtual ExpenseType ExpenseType { get; set; } = default!;
    
    [ForeignKey("CurrencyId")]
    [ValidateNever]
    public virtual Currency Currency { get; set; } = default!;

    [ForeignKey("UserId")]
    [ValidateNever]
    public virtual User User { get; set; } = default!;
}

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class Currency
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = null!;
}

public class ExpenseType
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; } = null!;
}