namespace Muscle
{
    using System.Collections.Generic;

    public class Region : AliasedEntityData
    {

        public string Description { get; set; }

        public ICollection<Muscle> Muscles { get; set; }
    }
}