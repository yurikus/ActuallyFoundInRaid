using EFT.InventoryLogic;

namespace PrivateRyan.ActuallyFIR.Helpers;

internal class Utils
{
    public static EquipmentSlot[] SlotsToProcess { get; } =
    [
        EquipmentSlot.FirstPrimaryWeapon,
        EquipmentSlot.SecondPrimaryWeapon,
        EquipmentSlot.Holster,
        EquipmentSlot.Scabbard,
        EquipmentSlot.Backpack,
        //EquipmentSlot.SecuredContainer,
        EquipmentSlot.TacticalVest,
        EquipmentSlot.ArmorVest,
        EquipmentSlot.Pockets,
        EquipmentSlot.Eyewear,
        EquipmentSlot.FaceCover,
        EquipmentSlot.Headwear,
        EquipmentSlot.Earpiece,
        //EquipmentSlot.Dogtag,
        EquipmentSlot.ArmBand,
    ];
    
    public static void ProcessSlot(Slot slot)
    {
        Item item = slot.ContainedItem;
        if (item != null)
        {
            item.SpawnedInSession = true;
            item.GetAllItems().ExecuteForEach(x => x.SpawnedInSession = true);
        }
    }
}