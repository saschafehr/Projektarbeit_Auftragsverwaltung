using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Auftragsverwaltung.Model
{
    public class ItemGroup
    {
        public int ItemGroupID { get; set; }
        public string Name { get; set; }

        public int? ParentID { get; set; }
        public virtual ItemGroup Parent { get; set; }

        public virtual List<ItemGroup> Childrens { get; set; }

        public virtual ICollection<Item> Items { get; set; }


    }
}
