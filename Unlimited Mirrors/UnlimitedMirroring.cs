using System;
using MelonLoader;
using UnityEngine;
using HarmonyLib;
using ABI_RC.Core.Player;
using ABI_RC.Core.Player.PortableMirror;

namespace Unlimited_Mirrors
{
    public static class BuildInfo
         {
             public const string Name = "Unlimited Mirrors";
             public const string Description = "A fun way to get 1 FPS";
             public const string Author = "Malthbern";
             public const string Company = null;
             public const string Version = "1.0.0";
             public const string DownloadLink = "https://github.com/Malthbern/UnlimitedMirrors/releases";
         }
    
    public class UnlimitedMirroring : MelonMod
    {
        

        public override void OnInitializeMelon()
        {
            try
            {
                HarmonyInstance.PatchAll(typeof(BigBrainPatch));
            }
            catch (Exception e)
            {
                MelonLogger.Error("No unlimited mirrors for you:\n" + e);
            }
        }
    }

    public class BigBrainPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PortableMirrorInstance), "CreateMirrorAtView")] 
        
        /*
         * The following code was taken from ChilloutVR's source with permission.
         * it has been slightly modified to ignore any limiting of how many mirrors can
         * be spawned at any time as well as to work as a Harmony patch
         *
         * This disclaimer is here to abide with §6.2 of the ChilloutVR ToS
         */
        
        public static bool CreateMirrorAtView(ref PortableMirrorInstance __result)
        {
            Transform playerCamTransform = PlayerSetup.Instance.activeCam.transform;
            Vector3 transForward = playerCamTransform.forward;
        
            PortableMirrorInstance mirrorInstance = PortableMirrorInstance.CreateMirror();
            mirrorInstance.transform.position = playerCamTransform.position + transForward * (PlayerSetup.Instance.GetPlaySpaceScale() * 1f);
            mirrorInstance.transform.rotation = Quaternion.LookRotation(transForward, PlayerSetup.Instance.transform.up);
        
            __result = mirrorInstance;
            return false;
        }
    }
}