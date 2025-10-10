using MelonLoader;
using System.Reflection;
using Unlimited_Mirrors;

[assembly: AssemblyDescription(Unlimited_Mirrors.BuildInfo.Description)]
[assembly: AssemblyCopyright("Created by " + Unlimited_Mirrors.BuildInfo.Author)]
[assembly: AssemblyTrademark(Unlimited_Mirrors.BuildInfo.Company)]
[assembly: MelonInfo(typeof(UnlimitedMirroring), Unlimited_Mirrors.BuildInfo.Name, Unlimited_Mirrors.BuildInfo.Version, Unlimited_Mirrors.BuildInfo.Author, Unlimited_Mirrors.BuildInfo.DownloadLink)]
[assembly: MelonColor(255, 252, 0, 177)]
[assembly: MelonAuthorColor(255, 0, 252, 177)]
[assembly: HarmonyDontPatchAll]