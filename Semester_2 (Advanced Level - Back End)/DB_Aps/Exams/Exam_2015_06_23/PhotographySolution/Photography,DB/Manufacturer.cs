//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Photography_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            this.Cameras = new HashSet<Camera>();
            this.Lenses = new HashSet<Lens>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Camera> Cameras { get; set; }
        public virtual ICollection<Lens> Lenses { get; set; }
    }
}
