using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Model
{
    public class OrderPosition
    {
        
        public int OrderPositionID { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public int Amount { get; set; }
        
    }
}
