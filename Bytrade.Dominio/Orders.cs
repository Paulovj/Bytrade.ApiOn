using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CompanyId { get; set; }
        public int WarehouseId { get; set; }
        public int DepartmentId { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string PortionName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int PortionCount { get; set; }
        public bool Locked { get; set; }
        public bool CalculatePrice { get; set; }
        public bool DecreaseInventory { get; set; }
        public bool IncreaseInventory { get; set; }
        public int OrderNumber { get; set; }
        public string CreatingUserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int AccountTransactionTypeId { get; set; }
        public int ProductTimerValueId { get; set; }
        public string PriceTag { get; set; }
        public string Tag { get; set; }
        public string Taxes { get; set; }
        public string OrderTags { get; set; }
        public string OrderStates { get; set; }

        public virtual Company Company { get; set; }
        public virtual ProductTimerValues ProductTimerValue { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
}
