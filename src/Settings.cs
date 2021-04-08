using ModSettings;

namespace BetterMendingXP
{
    internal class BetterMendingXPSettings : JsonModSettings
    {
        [Name("Crafting bandages sometimes give XP")]
        [Description("Crafting bandages have a 33% chance of giving mending experience.")]
        public bool CraftingBandagesGivesXP = true;

        [Name("Level required for crafting Rabbit Skin items")]
        [Description("Mending experience level required for crafting Rabbit Skin items")]
        [Slider(1, 5)]
        public int RabbitLevel = 1;

        [Name("Level required for crafting Deer Skin items")]
        [Description("Mending experience level required for crafting Deer Skin items")]
        [Slider(1, 5)]
        public int DeerLevel = 2;

        [Name("Level required for crafting Moose Hide items")]
        [Description("Mending experience level required for crafting Moose Hide items")]
        [Slider(1, 5)]
        public int MooseLevel = 3;

        [Name("Level required for crafting Wolfskin items")]
        [Description("Mending experience level required for crafting Wolfskin items")]
        [Slider(1, 5)]
        public int WolfLevel = 4;

        [Name("Level required for crafting Bearskin items")]
        [Description("Mending experience level required for crafting Bearskin items")]
        [Slider(1, 5)]
        public int BearLevel = 5;

        [Name("XP for crafting Improvised Clothing items")]
        [Description("Mending experience points for crafting Improvised Clothing items")]
        [Slider(0, 10)]
        public int ImprovisedXp = 1;

        [Name("XP for crafting Rabbit Skin items")]
        [Description("Mending experience points for crafting Rabbit Skin items")]
        [Slider(0, 10)]
        public int RabbitXp = 3;

        [Name("XP for crafting Deer Hide items")]
        [Description("Mending experience points for crafting Deer Hide items")]
        [Slider(0, 10)]
        public int DeerXp = 4;

        [Name("XP for crafting Moose Hide items")]
        [Description("Mending experience points for crafting Moose Hide items")]
        [Slider(0, 10)]
        public int MooseXp = 5;

        [Name("XP for crafting Wolfskin items")]
        [Description("Mending experience points for crafting Wolfskin items")]
        [Slider(0, 10)]
        public int WolfXp = 7;

        [Name("XP for crafting Bearskin items")]
        [Description("Mending experience points for crafting Bearskin items")]
        [Slider(0, 10)]
        public int BearXp = 8;
    }
    static class Settings
    {
        internal static BetterMendingXPSettings options;
        internal static void OnLoad()
        {
            options = new BetterMendingXPSettings();
            options.AddToModSettings("Better Mending XP");
        }
    }
}
