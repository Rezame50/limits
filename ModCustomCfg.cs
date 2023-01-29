using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

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
