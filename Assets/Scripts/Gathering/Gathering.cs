using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gathering : MonoBehaviour {
    
    public float harvestCooldown = 2f;
    private float actualCooldown;

    private Inventory inventory;
    private Stat harvestSkill;

	void Start () {
        inventory = Inventory.instance;
        harvestSkill = GetComponent<PlayerStats>().harvest;

        actualCooldown = harvestCooldown;
	}

    void Update(){
        actualCooldown -= Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D other){
        HarvestableItem harvestableItem = other.gameObject.GetComponent<HarvestableItem>();

        if(harvestableItem != null){
            Debug.Log("<color=blue>[GATHERING] Click para cosechar: " + other.collider.name + "</color>");

            if (Input.GetMouseButton(0) && actualCooldown <= 0){
                bool wasObtained = harvestableItem.Harvest( harvestSkill.getValue() );

                if( wasObtained ){
                    inventory.AddItem( harvestableItem.item );
                    other.gameObject.SetActive(false);
                }

                actualCooldown = harvestCooldown;
            }
        }
    }
}
