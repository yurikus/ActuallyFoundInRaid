using System.Collections.Generic;
using BepInEx.Configuration;

namespace PrivateRyan.ActuallyFIR.Helpers;

internal class Settings
{
    public const string GeneralSectionTitle = "1. General";
    public static ConfigFile Config;
    public static ConfigEntry<bool> ActuallyFIREnabled;
    public static List<ConfigEntryBase> ConfigEntries = [];

    public static void Init(ConfigFile Config)
    {
        Settings.Config = Config;

        ConfigEntries.Add(ActuallyFIREnabled = Config.Bind(
            GeneralSectionTitle,
            "ActuallyFIR Enabled",
            true,  // Default value
            new ConfigDescription(
                "Is Actually Found In Raid enabled?",
                null,
                new ConfigurationManagerAttributes { Order = 0 }
            )));

        RecalcOrder();
    }

    private static void RecalcOrder()
    {
        // Set the Order field for all settings, to avoid unnecessary changes when adding new settings
        int settingOrder = ConfigEntries.Count;
        foreach (var entry in ConfigEntries)
        {
            if (entry.Description.Tags[0] is ConfigurationManagerAttributes attributes)
            {
                attributes.Order = settingOrder;
            }

            settingOrder--;
        }
    }
}