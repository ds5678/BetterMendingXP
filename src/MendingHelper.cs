namespace BetterMendingXP
{
    public class MendingHelper
    {
        public static bool IsClothing(GearItem gearItem)
        {
            if (gearItem == null) return false;
            return gearItem.m_Type == GearTypeEnum.Clothing || gearItem.name == "GEAR_BearSkinBedRoll";
        }

        public static bool IsClothing(BlueprintItem blueprintItem)
        {
            return IsClothing(blueprintItem.m_CraftedResult);
        }

        public static bool IsBandage(GearItem gearItem)
        {
            return IsBandage(gearItem.name);
        }

        public static bool IsBandage(string itemName)
        {
            return itemName == "GEAR_HeavyBandage";
        }

        public static bool IsImprovisedClothing(string itemName)
        {
            return itemName == "GEAR_ImprovisedHat" || itemName == "GEAR_ImprovisedMittens";
        }

        public static void AddMendingXP(int xp)
        {
            GameManager.GetSkillsManager().IncrementPointsAndNotify(SkillType.ClothingRepair, xp, SkillsManager.PointAssignmentMode.AssignOnlyInSandbox);
        }

        public static int GetRequiredMendingLevel(BlueprintItem blueprintItem)
        {
            var gearItem = blueprintItem.m_CraftedResult;
            if (!IsClothing(gearItem))
            {
                return 0;
            }

            var name = gearItem.name;
            var settings = Settings.options;

            if (name.StartsWith("GEAR_Rabbit"))
                return settings.RabbitLevel;

            if (name.StartsWith("GEAR_Deer"))
                return settings.DeerLevel;

            if (name.StartsWith("GEAR_Moose"))
                return settings.MooseLevel;

            if (name.StartsWith("GEAR_Wolf"))
                return settings.WolfLevel;

            if (name.StartsWith("GEAR_Bear"))
                return settings.BearLevel;

            return 0;
        }

        public static int GetXpForCrafting(string itemName)
        {
            var settings = Settings.options;
            if (IsBandage(itemName) && settings.CraftingBandagesGivesXP)
            {
                if (Utils.RollChance(33f))
                {
                    return 1;
                }
                return 0;
            }

            if (IsImprovisedClothing(itemName))
                return settings.ImprovisedXp;

            if (itemName.StartsWith("GEAR_Rabbit"))
                return settings.RabbitXp;

            if (itemName.StartsWith("GEAR_Deer"))
                return settings.DeerXp;

            if (itemName.StartsWith("GEAR_Moose"))
                return settings.MooseXp;

            if (itemName.StartsWith("GEAR_Wolf"))
                return settings.WolfXp;

            if (itemName.StartsWith("GEAR_Bear"))
                return settings.BearXp;

            return 0;
        }

        public static int GetCurrentMendingLevel()
        {
            return GameManager.GetSkillClothingRepair().GetCurrentTierNumber() + 1;
        }
    }
}
