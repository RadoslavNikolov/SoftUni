//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planning.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nomenklatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nomenklatura()
        {
            this.Anestezia = new HashSet<Anestezia>();
            this.BList = new HashSet<BList>();
            this.BList1 = new HashSet<BList>();
            this.BolnichnoLechenie = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie1 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie2 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie3 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie4 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie5 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie6 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie7 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie8 = new HashSet<BolnichnoLechenie>();
            this.DispDosie = new HashSet<DispDosie>();
            this.DispGrupa = new HashSet<DispGrupa>();
            this.DoctorsSchedule = new HashSet<DoctorsSchedule>();
            this.IzoliranMikroorganizamData = new HashSet<IzoliranMikroorganizamData>();
            this.IzsDI = new HashSet<IzsDI>();
            this.IzsDI1 = new HashSet<IzsDI>();
            this.IzsDI2 = new HashSet<IzsDI>();
            this.IzsDI3 = new HashSet<IzsDI>();
            this.IzsEFI = new HashSet<IzsEFI>();
            this.IzsEFI1 = new HashSet<IzsEFI>();
            this.IzsEFI2 = new HashSet<IzsEFI>();
            this.IzsFNI = new HashSet<IzsFNI>();
            this.IzsFNI1 = new HashSet<IzsFNI>();
            this.IzsIP = new HashSet<IzsIP>();
            this.IzsIP1 = new HashSet<IzsIP>();
            this.IzsIP2 = new HashSet<IzsIP>();
            this.IzsLAB = new HashSet<IzsLAB>();
            this.IzsLAB1 = new HashSet<IzsLAB>();
            this.IzsROD = new HashSet<IzsROD>();
            this.IzsROD1 = new HashSet<IzsROD>();
            this.IzsVSI = new HashSet<IzsVSI>();
            this.IzsVSI1 = new HashSet<IzsVSI>();
            this.IzvunNKBKons = new HashSet<IzvunNKBKons>();
            this.Konsultacia = new HashSet<Konsultacia>();
            this.Konsultacia1 = new HashSet<Konsultacia>();
            this.Konsultacia2 = new HashSet<Konsultacia>();
            this.MedCentar = new HashSet<MedCentar>();
            this.MedTerapia = new HashSet<MedTerapia>();
            this.MikrobiologichnoIzsledvane = new HashSet<MikrobiologichnoIzsledvane>();
            this.MikrobiologichnoIzsledvane1 = new HashSet<MikrobiologichnoIzsledvane>();
            this.MikrobiologichnoIzsledvane2 = new HashSet<MikrobiologichnoIzsledvane>();
            this.MikroskopskiPreparatData = new HashSet<MikroskopskiPreparatData>();
            this.Nomenklatura1 = new HashSet<Nomenklatura>();
            this.NZOKAmbGrafik = new HashSet<NZOKAmbGrafik>();
            this.Operacia = new HashSet<Operacia>();
            this.Operacia1 = new HashSet<Operacia>();
            this.Operacia2 = new HashSet<Operacia>();
            this.Operacia3 = new HashSet<Operacia>();
            this.Personal = new HashSet<Personal>();
            this.Pochinali = new HashSet<Pochinali>();
            this.Pregled = new HashSet<Pregled>();
            this.Pregled1 = new HashSet<Pregled>();
            this.Pregled2 = new HashSet<Pregled>();
            this.Pregled3 = new HashSet<Pregled>();
            this.Pregled4 = new HashSet<Pregled>();
            this.Proceduri = new HashSet<Proceduri>();
            this.Proceduri1 = new HashSet<Proceduri>();
            this.Trudozaguba = new HashSet<Trudozaguba>();
            this.Zveno = new HashSet<Zveno>();
            this.Zveno1 = new HashSet<Zveno>();
            this.Zveno2 = new HashSet<Zveno>();
            this.PregnancyRegister = new HashSet<PregnancyRegister>();
            this.PregnancyRegister1 = new HashSet<PregnancyRegister>();
        }
    
        public decimal NomenklaturaID { get; set; }
        public Nullable<decimal> NomenklaturaSelfID { get; set; }
        public string NomIme { get; set; }
        public decimal NomSort { get; set; }
        public bool NomIsInvisible { get; set; }
        public string NomKod { get; set; }
        public decimal NomPostID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anestezia> Anestezia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BList> BList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BList> BList1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie6 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie7 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie8 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispDosie> DispDosie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispGrupa> DispGrupa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorsSchedule> DoctorsSchedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzoliranMikroorganizamData> IzoliranMikroorganizamData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsEFI> IzsEFI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsEFI> IzsEFI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsEFI> IzsEFI2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsFNI> IzsFNI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsFNI> IzsFNI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP> IzsIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP> IzsIP1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP> IzsIP2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsLAB> IzsLAB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsLAB> IzsLAB1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsROD> IzsROD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsROD> IzsROD1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsVSI> IzsVSI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsVSI> IzsVSI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzvunNKBKons> IzvunNKBKons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Konsultacia> Konsultacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Konsultacia> Konsultacia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Konsultacia> Konsultacia2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedCentar> MedCentar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedTerapia> MedTerapia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MikrobiologichnoIzsledvane> MikrobiologichnoIzsledvane { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MikrobiologichnoIzsledvane> MikrobiologichnoIzsledvane1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MikrobiologichnoIzsledvane> MikrobiologichnoIzsledvane2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MikroskopskiPreparatData> MikroskopskiPreparatData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nomenklatura> Nomenklatura1 { get; set; }
        public virtual Nomenklatura Nomenklatura2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZOKAmbGrafik> NZOKAmbGrafik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal> Personal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pochinali> Pochinali { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceduri> Proceduri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceduri> Proceduri1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trudozaguba> Trudozaguba { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zveno> Zveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zveno> Zveno1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zveno> Zveno2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PregnancyRegister> PregnancyRegister { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PregnancyRegister> PregnancyRegister1 { get; set; }
    }
}
