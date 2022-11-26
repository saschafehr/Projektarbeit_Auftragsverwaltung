using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Title { get; set; }
        // [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        public int ItemGroupID { get; set; }
        public virtual ItemGroup ItemGroup { get; set; }
        public int VATID { get; set; }
        public virtual VAT VAT { get; set; }

        public virtual ICollection<OrderPosition> OrderPosition { get; set; }
    }
}
