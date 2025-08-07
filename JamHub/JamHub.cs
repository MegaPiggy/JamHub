using HarmonyLib;
using OWML.Common;
using OWML.ModHelper;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace JamHub
{
    public class JamHub : ModBehaviour
    {
        public INewHorizons newHorizons = null;
        public List<OtherMod> mods;

        //Static
        public static JamHub instance;

        private void Start()
        {

            // Get the New Horizons API and load configs
            newHorizons = ModHelper.Interaction.TryGetModApi<INewHorizons>("xen.NewHorizons");
            newHorizons.LoadConfigs(this);

            //Set ourselves up to do stuff when the system loads
            UnityEvent<string> loadCompleteEvent = newHorizons.GetStarSystemLoadedEvent();
            loadCompleteEvent.AddListener(JamSystemHelper.PrepSystem);

            //Make all of the patches
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            // Say that we're done
            instance = this;
            ModHelper.Console.WriteLine($"My mod {nameof(JamHub)} is loaded!", MessageType.Success);
        }

        public static void DebugPrint(string message)
        {
            instance.ModHelper.Console.WriteLine(message);
        }
    }
}
