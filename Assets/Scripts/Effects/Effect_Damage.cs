using UnityEngine;

public class Effect_Damage: EffectBase {
    
    private string damage_type;

    public Effect_Damage(CharacterBase from, CharacterBase to, float value ){
        this.caster = from;
        this.target = to;
        this.value = value;
        this.damage_type = "phisical";
    }

    public override void cast(){
        this.target.damageTaken((int)value);
        Debug.Log("Deal " + value.ToString() + this.damage_type +" damage to " + this.target.name);
    }
}