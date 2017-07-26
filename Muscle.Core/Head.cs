namespace Muscle
{
    using System.Collections.Generic;

    public class Head : AliasedEntityData
    {
        public string Description { get; set; }

        public string MuscleId { get; set; }

        public Muscle Muscle { get; set; }
    }
}