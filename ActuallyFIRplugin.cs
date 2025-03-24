using BepInEx;
using PrivateRyan.ActuallyFIR.Helpers;
using PrivateRyan.ActuallyFIR.Patches;

namespace PrivateRyan.ActuallyFIR;

[BepInPlugin("privateryan.actuallyfir", "ActuallyFoundInRaid", Version)]
[BepInDependency("com.SPT.core", "3.11.0")]
public class ActuallyFIRPlugin : BaseUnityPlugin
{
    public const string Version = "1.1.0";

    private void Awake()
    {
        Settings.Init(Config);

        new BotBrainActivatePatch().Enable();
    }
}