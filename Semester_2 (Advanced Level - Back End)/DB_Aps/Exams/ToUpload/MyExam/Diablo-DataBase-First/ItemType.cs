//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diablo_DataBase_First
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemType
    {
        public ItemType()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
    }
}