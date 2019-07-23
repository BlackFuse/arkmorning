using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    // Start is called before the first frame update
    void Start()
    {
        // this.init();
        this.character_type = "enemy";
    }
    
    public override void die(){
        Debug.Log(this.name + " is dead");
    }
}
