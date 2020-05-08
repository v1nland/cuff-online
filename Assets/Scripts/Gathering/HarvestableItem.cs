using UnityEngine;

public class HarvestableItem : ItemPickup {
    
    public int maxResistance = 100;
    public int currentResistance;

    private void Start(){
        currentResistance = maxResistance;
    }

    public bool Harvest( int harvestValue ){
        currentResistance -= harvestValue;

        Debug.Log("<color=blue>[GATHERING] " + transform.name + " recibe " + harvestValue + " de dano, puntos de resistencia actuales: " + currentResistance + "</color>");

        if (currentResistance <= 0){
            Debug.Log("<color=blue>[GATHERING] " + transform.name + " fue cosechado</color>");

            currentResistance = maxResistance;

            return true;
        }

        return false;
    }
}
