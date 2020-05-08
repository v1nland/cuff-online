using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100; // some value
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake(){
        currentHealth = maxHealth;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Z)){
            TakeDamage(10);
        }
    }

    void TakeDamage( int dmg ){
        dmg -= armor.getValue();
        dmg = Mathf.Clamp( dmg, 0, int.MaxValue );

        currentHealth -= dmg;
        Debug.Log("<color=green>[STATS] " + transform.name + " recibe " + dmg + " de dano, nueva vida actual: " + currentHealth + "</color>" );

        if( currentHealth <= 0 ){
            // Die();
            Debug.Log("<color=green>[STATS] Ha muerto el jugador</color>");
        }
    }
}
