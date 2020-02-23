using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Verse;

using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse.Steam;

namespace NoDivorce
{
    [StaticConstructorOnStartup]
    class NoDivorce : Mod
    {
        public NoDivorce(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("net.pog.rimworld.mod.nodivorce");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }

    [HarmonyPatch(typeof(InteractionWorker_Breakup))]
    [HarmonyPatch(nameof(InteractionWorker_Breakup.RandomSelectionWeight))]
    class Patch
    {
        static bool Prefix(ref float __result)
        {
            //Log.Error("Is it running?", false);
			__result = 0f;
            return false;
        }
    }

}
