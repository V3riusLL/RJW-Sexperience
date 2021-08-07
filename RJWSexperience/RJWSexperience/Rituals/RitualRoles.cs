using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using rjw;

namespace RJWSexperience
{
    public class RitualRole_RapeVictim : RitualRole
    {
        public override bool AppliesToRole(Precept_Role role, out string reason, Precept_Ritual ritual = null, Pawn pawn = null, bool skipReason = false)
        {
            reason = null;
            return false;
        }

        public override bool AppliesToPawn(Pawn p, out string reason, LordJob_Ritual ritual = null, RitualRoleAssignments assignments = null, Precept_Ritual precept = null, bool skipReason = false)
        {
            reason = null;
            if (CanBeVictim(p)) return true;
            if (!skipReason)
            {
                reason = Keyed.RSVictimCondition;
            }
            return false;
        }

        public static bool CanBeVictim(Pawn pawn)
        {
            if (pawn.IsPrisonerOfColony || pawn.IsSlaveOfColony) return true;
            if (pawn.Ideo?.HasMeme(MemeDefOf.FemaleSupremacy) ?? false && pawn.gender != Gender.Female) return true;
            else if (pawn.Ideo?.HasMeme(MemeDefOf.MaleSupremacy) ?? false && pawn.gender != Gender.Male) return true;
            else if (pawn.IsDesignatedComfort() || (pawn.guilt != null && pawn.guilt.IsGuilty) || (pawn.apparel != null && pawn.apparel.PsychologicallyNude)) return true;
            return false;
        }
    }

    public class RitualRole_HumanBreedee : RitualRole
    {
        public override bool AppliesToRole(Precept_Role role, out string reason, Precept_Ritual ritual = null, Pawn pawn = null, bool skipReason = false)
        {
            reason = null;
            return false;
        }

        public override bool AppliesToPawn(Pawn p, out string reason, LordJob_Ritual ritual = null, RitualRoleAssignments assignments = null, Precept_Ritual precept = null, bool skipReason = false)
        {
            reason = null;
            if (!xxx.is_human(p))
            {
                reason = Keyed.RSNotHuman;
                return false;
            }
            if (CanBeBreedee(p)) return true;
            if (!skipReason)
            {
                reason = Keyed.RSShouldCanFuck;
            }
            return false;
        }

        public static bool CanBeBreedee(Pawn pawn)
        {
            if (xxx.can_be_fucked(pawn)) return true;
            return false;
        }
    }

    public class RitualRole_AnimalBreeder : RitualRole
    {
        public override bool Animal => true;

        public override bool AppliesToRole(Precept_Role role, out string reason, Precept_Ritual ritual = null, Pawn pawn = null, bool skipReason = false)
        {
            reason = null;
            return false;
        }

        public override bool AppliesToPawn(Pawn p, out string reason, LordJob_Ritual ritual = null, RitualRoleAssignments assignments = null, Precept_Ritual precept = null, bool skipReason = false)
        {
            reason = null;
            if (!p.IsAnimal())
            {
                reason = Keyed.RSNotAnimal;
                return false;
            }
            if (CanBeBreeder(p, assignments?.Ritual)) return true;
            if (!skipReason)
            {
                reason = Keyed.RSBreederCondition;
            }
            return false;
        }

        public static bool CanBeBreeder(Pawn animal, Precept_Ritual precept)
        {
            //if (precept != null)
            //{
            //    if (precept.ideo.HasPrecept(VariousDefOf.Bestiality_OnlyVenerated) && !precept.ideo.IsVeneratedAnimal(animal)) return false;
            //}
            if (!xxx.can_rape(animal)) return false;
            return true;
        }

    }


}
