using Apwd.GestorLine.Domain.Entities.v1.System;

namespace Apwd.GestorLine.Domain.Entities.v1.Product
{
    public class Product : BaseEntity
    {
        public required string Status { get; set; }
        public required string InternalCode { get; set; }
        public required string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string? Comments { get; set; }
    }
}