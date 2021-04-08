using MelonLoader;
using UnityEngine;

namespace BetterMendingXP
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
        internal static void Log(string message, params object[] parameters) => MelonLogger.Log(message, parameters);
    }
}
