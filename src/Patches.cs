using Harmony;
using UnityEngine;

namespace BetterMendingXP
{
    class Patches
    {
        [HarmonyPatch(typeof(BlueprintItem))]
        [HarmonyPatch("CanCraftBlueprint")]
        class PatchBlueprintItem_CanCraftBlueprint
        {
            static void Postfix(ref bool __result, BlueprintItem __instance)
            {
                if (__result == false) return;

                var mendingLevel = MendingHelper.GetCurrentMendingLevel();
                var requiredMendingLevel = MendingHelper.GetRequiredMendingLevel(__instance);
                if (mendingLevel < requiredMendingLevel)
                {
                    __result = false;
                }
            }
        }

        [HarmonyPatch(typeof(Panel_Crafting), "RefreshSelectedBlueprint")]
        public class PatchCraftingPageDescriptionText
        {
            const float WhiteColorValue = 0.7843137f;
            private static readonly Color WhiteColor = new Color(WhiteColorValue, WhiteColorValue, WhiteColorValue);
            private static readonly Color RedColor = new Color(0.7f, 0f, 0f);

            private static void Postfix(Panel_Crafting __instance)
            {
                __instance.m_SelectedDescription.color = WhiteColor;
                var bpi = __instance.m_SelectedBPI;
                if (!bpi)
                {
                    return;
                }
                if (!bpi.m_CraftedResult)
                {
                    return;
                }

                if (!MendingHelper.IsClothing(bpi))
                {
                    return;
                }

                var mendingLevel = MendingHelper.GetCurrentMendingLevel();
                var requiredMendingLevel = MendingHelper.GetRequiredMendingLevel(bpi);
                if (mendingLevel < requiredMendingLevel)
                {
                    __instance.m_SelectedDescription.text = "REQUIRES MENDING LEVEL " + requiredMendingLevel;
                    __instance.m_SelectedDescription.color = RedColor;
                }
            }
        }

        [HarmonyPatch(typeof(AchievementManager))]
        [HarmonyPatch("CraftedItem")]
        public class PatchCrafteditem
        {
            public static void Prefix(string itemName)
            {
                Implementation.Log("Crafted " + itemName);
                var xp = MendingHelper.GetXpForCrafting(itemName);
                if (xp > 0)
                {
                    MendingHelper.AddMendingXP(xp);
                }
            }
        }
    }
}
