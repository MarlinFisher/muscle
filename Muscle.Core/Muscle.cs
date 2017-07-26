namespace Muscle
{
    using System.Collections.Generic;

    public class Muscle : AliasedEntityData
    {
        public bool Major { get; set; }

        public string Description { get; set; }

        public string RegionId { get; set; }

        public virtual ICollection<Head> Heads { get; set; }
    }
}
