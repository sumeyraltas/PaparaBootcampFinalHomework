namespace PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs
{
    public class GasBillsDTO
    {
        public required int Id { get; set; }
        public required decimal GasBill { get; set; }
        public required bool IsPaid { get; set; }
        public required int Year { get; set; }
        public required int Month { get; set; }
    }
}