using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {
    
    public EquipmentSlot equipSlot;
    public Sprite equipSprite;

    public int armorModifier;
    public int damageModifier;
    public int harvestModifier;

    public override void Use(){
        base.Use();

        InventoryEquipment.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
