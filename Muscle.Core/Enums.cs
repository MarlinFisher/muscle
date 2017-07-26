namespace Muscle
{
    public enum Forces
    {
        Push,
        Pull,
        Slide,
        Rotate
    }

    public enum Contractions
    {
        Isotonic,
        Isokinetic,
        Concentric,
        Eccentric,
        Dynamic,
        Isometric
    }

    public enum Movements
    {
        Abduction,
        Adduction,
        Circumduction,
        Extension,
        Eversion,
        Flexion,
        Hyperextension,
        Inversion,
        Pronation,
        Protrusion,
        Supination,
        Retrusion,
        Rotation
    }

    public enum ResistanceCurves
    {
        GravityDependent,
        Variable,
        Bell,
        Ascending,
        Descending
    }

    public enum MuscleRole
    {
        Agonist,
        Antagonist,
        Target,
        Synergist,
        Stabilizer,
        DynamicStabilizer,
        AntagonistStabilizer
    }

    public enum MuscleFibers
    {
        // Slow
        I,
        // Medium
        IIA,
        // Fast
        IIX
    }
}