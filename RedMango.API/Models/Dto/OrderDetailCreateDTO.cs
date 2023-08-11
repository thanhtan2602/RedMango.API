using System.ComponentModel.DataAnnotations;

namespace RedMango.API.Models.Dto
{
    public class OrderDetailCreateDTO
    {
        public int MenuItemId { get; set; }
        public int Quanlity { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
    }
}
