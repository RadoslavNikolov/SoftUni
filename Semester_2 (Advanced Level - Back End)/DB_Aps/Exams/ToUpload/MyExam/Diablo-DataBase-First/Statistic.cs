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
    
    public partial class Statistic
    {
        public Statistic()
        {
            this.Characters = new HashSet<Character>();
            this.GameTypes = new HashSet<GameType>();
            this.Items = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public int Mind { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }
    
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<GameType> GameTypes { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
