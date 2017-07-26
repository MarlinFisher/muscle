namespace Muscle
{
    using System.Collections.Generic;

    public class AliasedEntityData : EntityData
    {
        public string Name { get; set; }

        public ICollection<Alias> Aliases { get; set; }
    }
}