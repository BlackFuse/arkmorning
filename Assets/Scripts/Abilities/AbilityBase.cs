using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase:MonoBehaviour
{
    public int id;
    public string abilityName;
    public string description;
    public CharacterBase owner;
    public int cooldown;
    public int cost;
    public string costType;
    public int value;
    public string type;
    public string targetType;

    public abstract void cast(CharacterBase target);
    public abstract void updateDescription();
    public abstract void onClick();
    public virtual string getAbilityTargetType(){
        return this.targetType;
    }

    public virtual void selectedThis(){
        this.gameObject.GetComponent<UISprite>().enabled = true;
    }

    public virtual void cancelSeleted(){
        this.gameObject.GetComponent<UISprite>().enabled = false;
    }

    public virtual void loadAbilityDataBasedOnId(int id){
        
    }

}
