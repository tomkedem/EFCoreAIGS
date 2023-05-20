using System.ComponentModel.DataAnnotations;

namespace EFCoreproject.Data
{
   public class SpendingDetail
    {
        [Key]
        public int SpendingDetailId { get; set; }
        public string SpentOn { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
