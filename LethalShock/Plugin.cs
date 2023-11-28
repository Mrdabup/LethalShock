﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BepInEx;
using HarmonyLib;
using BepInEx.Configuration;
using System.Net;
using System.Security.Policy;
using LethalShock.Patches;

namespace LethalShock
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LethalShockBase : BaseUnityPlugin
    {
        //Names
        private const string modGUID = "MrdTika.LethalShock";
        private const string modName = "Lethal Shock";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static LethalShockBase Instance;

        private const string Name = "Lethal_Shock_CMD"; //Name for the bot that shows up in logs

        internal static ConfigFile CustomConfigFile { get; set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            CustomConfigFile = new ConfigFile(Paths.ConfigPath + "\\LethalShockConf.cfg", true);
            CustomConfigFile.Bind<string>("USERNAME", "Username", "JohnDoe", (ConfigDescription)null);
            CustomConfigFile.Bind<string>("API", "ApiKey", "5c678926-d19e-4f86-42ad-21f5a76126db", (ConfigDescription)null);
            CustomConfigFile.Bind<string>("SHARECODE", "Code", "17519CD8GAP", (ConfigDescription)null);
            harmony.PatchAll(typeof(LethalShockBase));
            harmony.PatchAll(typeof(CheckPlayer));
            Logger.LogInfo("If you see this, hello!");
        }
    }
}
