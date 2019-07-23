using UnityEngine;

public class Effect_Heal: EffectBase {
    

    public Effect_Heal(CharacterBase from, CharacterBase to, float value ){
        this.caster = from;
        this.target = to;
        this.value = value;
    }

    public override void cast(){
        this.target.healTaken((int)value);
    }
}