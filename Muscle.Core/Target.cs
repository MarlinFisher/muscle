namespace Muscle
{
    public class Target : EntityData
    {
        public double Percentage { get; set; }

        public string ExerciseId { get; set; }

        public string HeadId { get; set; }

        public virtual Head Head { get; set; }
    }
}