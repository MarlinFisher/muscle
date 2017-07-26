namespace Muscle
{
    using System;
    using System.Data.Entity;
    using System.Runtime.CompilerServices;

    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected DataContext Context { get; set; }

        public void MigrationSeed(DataContext context)
        {
            this.Seed(context);
        }

        protected override void Seed(DataContext context)
        {
            this.Context = context;

            // Neck
            var neck = this.BuildRegion("Neck");
            var splenius = this.Muscle(neck, false, "Splenius", "Rear Neck", "Neck Extensors");
            var cervicis = this.Head(splenius, "Cervicis Splenius", "Cervicis", "Bottom", "Little");
            var capitis = this.Head(splenius, "Capitis Splenius", "Capitis", "Top", "Big");
            var stern = this.Muscle(neck, false, "Sternocleidomastoid", "Front Neck", "Neck Flexors");
            var anterior = this.Head(stern, "Anterior Fibers", "Anterior", "Front");
            var posterior = this.Head(stern, "Posterior Fibers", "Posterior", "Rear");

            // Shoulders
            var shoulders = this.BuildRegion("Shoulders");
            var delt = this.Muscle(shoulders, true, "Delts", "Deltoids", "Shoulders");
            var antDelt = this.Head(delt, "Anterior Deltoid", "Anterior", "Front");
            var latDelt = this.Head(delt, "Lateral Deltoid", "Lateral", "Middle", "Top");
            var postDelt = this.Head(delt, "Posterior Deltoid", "Posterior", "Rear");

            // Arms
            var arms = this.BuildRegion("Arms");
            var tri = this.Muscle(arms, true, "Triceps", "Triceps Brachii", "Tris");
            var triLat = this.Head(tri, "Lateral Head", "Lateral", "Outer");
            var triLong = this.Head(tri, "Long Head", "Long", "Inner");
            var triMed = this.Head(tri, "Medial Head", "Medial", "Middle");
            var bi = this.Muscle(arms, true, "Biceps", "Biceps Brachii", "Bis");
            var biLong = this.Head(bi, "Long Head", "Long", "Outer");
            var biShort = this.Head(bi, "Short Head", "Short", "Inner");

            // Forearms
            var forearms = this.BuildRegion("Forearms");
            var brach = this.Muscle(forearms, false, "Brachioradialis");
            var brachHead = this.Head(brach, "Brachioradialis");
            var wristflex = this.Muscle(forearms, false, "Wrist Flexor");
            var superFlex = this.Head(wristflex, "Flexor Digitorum Superficialis");
            var proFlex = this.Head(wristflex, "Flexor Digitorum Profundus");
            var radFlex = this.Head(wristflex, "Flexor Carpi Radialis");
            var ulnFlex = this.Head(wristflex, "Flexor Carpi Ulnaris");
            var palmFlex = this.Head(wristflex, "Palmaris Longus");
            var pollFlex = this.Head(wristflex, "Flexor Pollicis Longus");
            var ext = this.Muscle(forearms, false, "Wrist Extensors");
            var digiExt = this.Head(ext, "Extensor Digitorum");
            var radLongExt = this.Head(ext, "Extensor Carpi Radialis Longus");
            var readBrevExt = this.Head(ext, "Extensor Carpi Radialis Brevis");
            var ulnExt = this.Head(ext, "Extensor Carpi Ulnaris");
            var indicExt = this.Head(ext, "Extensor Indicis");
            var miniExt = this.Head(ext, "Extensor Digiti Minimi");
            var pollLongExt = this.Head(ext, "Entensor Pollicis Longus");
            var pollBrevExt = this.Head(ext, "Extensor Pollicis Brevis");

            // Back
            var back = this.BuildRegion("Back");
            var lat = this.Muscle(back, true, "Lats", "Latissimus Dorsi", "Outer Back");
            var latHead = this.Head(lat, "Lats", "Latissimus Dorsi", "Outer Back");
            //var teres = this.Muscle(back, false, "Teres");
            //var terMajor = this.Head(teres, "Teres Major");
            //var terMinor = this.Head(teres, "Teres Minor");
            var trap = this.Muscle(back, false, "Traps", "Trapezius");
            var upTrap = this.Head(trap, "Upper Fibers", "Upper", "Inner Shoulder");
            var midTrap = this.Head(trap, "Middle Fibers", "Middle", "Upper Back");
            var lowTrap = this.Head(trap, "Lower Fibers", "Lower", "Middle Back");
            //var rhom = this.Muscle(back, false, "Rhomboids");
            //var rhomMajor = this.Head(rhom, "Rhomboids Major");
            //var rhomMinor = this.Head(rhom, "Rhomboids Minor");
            var spine = this.Muscle(back, false, "Erector Spinae", "Lower Back");
            var iliSpine = this.Head(spine, "Iliocastalis");
            var longSpine = this.Head(spine, "Longissimus");
            var spineSpine = this.Head(spine, "Spinalis");
            //var infra = this.Muscle(back, false, "Infraspinatus");
            //var supInf = this.Head(infra, "Superior");
            //var midInf = this.Head(infra, "Middle");
            //var infInf = this.Head(infra, "Inferior");

            // Check
            var chest = this.BuildRegion("Chest");
            var pec = this.Muscle(chest, true, "Pecs", "Pectoralis Major");
            var clavPec = this.Head(pec, "Clavicular Head", "Upper Pecs", "Upper");
            var sternPec = this.Head(pec, "Sternal Head", "Lower Pecs", "Lower");

            // Waist
            var waist = this.BuildRegion("Waist", "Stomach", "Belly");
            var ab = this.Muscle(waist, true, "Abs", "Abdomen", "Rectus Abdominis");
            var abHead = this.Head(ab, "Abs", "Abdomen", "Rectus Abdominis");
            var obl = this.Muscle(waist, false, "Obliques", "Outer Waist", "Upper Hips");
            var extObl = this.Head(obl, "External Oblique");
            var intObl = this.Head(obl, "Internal Oblique");

            // Hips
            var hips = this.BuildRegion("Hips");
            var max = this.Muscle(hips, true, "Glutes", "Gluteus Maximus", "Buttocks", "Butt");
            var upMax = this.Head(max, "Upper Fibers");
            var lowMax = this.Head(max, "Lower Fibers");
            var med = this.Muscle(hips, false, "Gluteus Medius"); // Hip Abductor
            var antMed = this.Head(med, "Anterior Fibers");
            var postMed = this.Head(med, "Posterior  Fibers");
            var min = this.Muscle(hips, false, "Gluteus Minimus"); // Hip Abductor
            var minHead = this.Head(min, "Gluteus Minimus");
            var hipflex = this.Muscle(hips, false, "Hip Flexors");
            var hipFlexHead = this.Head(hipflex, "Tensor Fasciae Latae");

            // Thighs
            var thighs = this.BuildRegion("Thighs");
            var quad = this.Muscle(thighs, true, "Quads", "Quadriceps");
            var femQuad = this.Head(quad, "Rectus Femoris");
            var latQuad = this.Head(quad, "Vastus Lateralis (Externus)");
            var interQuad = this.Head(quad, "Vastus Intermedius");
            var medQuad = this.Head(quad, "Vastus Medialis (Internus)");
            var ham = this.Muscle(thighs, true, "Hamstrings");
            var longHam = this.Head(ham, "Long Head", "Long");
            var shortHam = this.Head(ham, "Short Head", "Short");
            var tendinHam = this.Head(ham, "Semitendinosus");
            var membranHam = this.Head(ham, "Semimembranosus");
            var add = this.Muscle(thighs, false, "Adductors", "Add", "Inner Thigh");
            var brevAdd = this.Head(add, "Adductor Brevis", "Brevis");
            var longAdd = this.Head(add, "Adductor Longus", "Longus");
            var magnAdd = this.Head(add, "Adductor Magnus", "Magnus");

            // Calves
            var calf = this.BuildRegion("Calf");
            var gastro = this.Muscle(calf, false, "Gastrocnemius");
            var latGastro = this.Head(gastro, "Lateral Head");
            var medGastro = this.Head(gastro, "Medial Head");
            var sol = this.Muscle(calf, false, "Soleus");
            var solHead = this.Head(sol, "Soleus");
            var tib = this.Muscle(calf, false, "Tibialis Anterior");
            var tibHead = this.Head(tib, "Tibialis Anterior");
            var pop = this.Muscle(calf, false, "Popliteus");
            var popHead = this.Head(pop, "Popliteus");

            this.Context = null;

            base.Seed(context);
        }

        private Region BuildRegion(params string[] aliases)
        {
            var entity = this.Context.Set<Region>().Add(new Region { Id = this.NewId(), Name = aliases[0] });
            this.AddAliases(entity, aliases);
            return entity;
        }

        private Muscle Muscle(Region region, bool isMajor, params string[] aliases)
        {
            var entity = this.Context.Set<Muscle>().Add(new Muscle { Id = this.NewId(), Name = aliases[0], RegionId = region.Id, Major = isMajor });
            this.AddAliases(entity, aliases);
            return entity;
        }

        private Head Head(Muscle muscle, params string[] aliases)
        {
            var entity = this.Context.Set<Head>().Add(new Head { Id = this.NewId(), Name = aliases[0], MuscleId = muscle.Id });
            this.AddAliases(entity, aliases);
            return entity;
        }

        private void AddAliases(AliasedEntityData entity, string[] aliases)
        {
            if (aliases == null)
                throw new ArgumentNullException(nameof(aliases));

            var length = aliases.Length;
            for (var index = 0; index < length; index++)
            {
                var alias = aliases[index];
                entity.Aliases.Add(new Alias { Id = this.NewId(), Name = alias, IsDefault = index == 0 });
            }
        }

        private string NewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}