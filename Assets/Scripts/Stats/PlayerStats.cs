using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {
    
    public Stat harvest;

	void Start () {
        InventoryEquipment.instance.onEquipmentChanged += OnEquipmentChanged;
	}

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem){
        if(newItem != null){
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
            harvest.AddModifier(newItem.harvestModifier);
        }

        if(oldItem != null){
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            harvest.RemoveModifier(oldItem.harvestModifier);
        }
    }
}
