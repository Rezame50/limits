using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace limits
{
    [BackgroundColor(32, 32, 32, 200)]
    [Label("Configuration (Server)")]
    public class limits_ModCustomCFGServer : ModConfig
    {
        public static limits_ModCustomCFGServer CFG_S => ModContent.GetInstance<limits_ModCustomCFGServer>();
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Main Settings")]

        [Label("Max Projectiles")]
        [Tooltip("Restart the game.\n1000 = default")]
        [Range(0, Main.maxProjectiles)]
        [Increment(1)]
        [DefaultValue(Main.maxProjectiles)]
        public int MaxProjectiles;

        [Label("Max NPCs")]
        [Tooltip("Restart the game.\n200 = default")]
        [Range(0, Main.maxNPCs)]
        [Increment(1)]
        [DefaultValue(Main.maxNPCs)]
        public int MaxNPCs;

        [Label("Update on World Load")]
        [Tooltip("Allows to just re-enter your world instead of restarting the game. Shouldn't but MAY cause errors.\true = default")]
        [Range(0, Main.maxNPCs)]
        [Increment(1)]
        [DefaultValue(true)]
        public bool UpdateOnWorldLoad;
    }
}
