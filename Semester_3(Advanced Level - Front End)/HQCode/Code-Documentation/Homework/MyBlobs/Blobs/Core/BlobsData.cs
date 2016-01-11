namespace Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using Models.Inftrastructure;

    public class BlobsData : IBlobsData
    {
        private readonly IList<IUnit> blobs;

        public BlobsData()
        {
            this.blobs = new List<IUnit>();
        }

        public IEnumerable<IUnit> Blobs
        {
            get { return this.blobs; }
        }

        public void AddBlob(IUnit unit)
        {
            if (this.blobs.Any(u => u.Name == unit.Name))
            {
                throw new ArgumentException("Such unit already exists");
            }

            this.blobs.Add(unit);
        }

        public IUnit GetUnit(string unitName)
        {
            IUnit unit = this.blobs.FirstOrDefault(u => u.Name.ToLowerInvariant().Equals(unitName.ToLowerInvariant()));

            if (unit == null)
            {
                throw new InvalidOperationException("There is no such blob with this name");
            }

            return unit;
        }
    }
}