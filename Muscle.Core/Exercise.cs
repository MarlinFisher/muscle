namespace Muscle
{
    using System.Collections.Generic;

    public class Exercise : AliasedEntityData
    {
        public string Description { get; set; }
        public string Instructions { get; set; }
        public ExerciseType Type { get; set; }

        public string EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<Target> Distribution { get; set; }
    }
}