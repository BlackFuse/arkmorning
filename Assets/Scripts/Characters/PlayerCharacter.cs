using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : CharacterBase
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void init(int HP, int max_HP, string energy_type ,
        int energy, int max_energy, int speed ){
        
    }

    public override void die(){
        Debug.Log(this.name + " is dead");
    }
    
}
