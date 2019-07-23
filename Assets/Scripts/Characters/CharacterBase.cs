using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase: MonoBehaviour
{
    public CharacterData data;
    protected string character_type;
    protected string statu;
    protected List<BuffBase> buff_list = new List<BuffBase>();
    protected List<EffectBase> gear_list = new List<EffectBase>();
    public List<AbilityBase> ability_list = new List<AbilityBase>();
    public Dictionary<string, float> properties_scale = new Dictionary<string, float>();

    public UISlider HPBar;
    public UISlider EnergyBar; 
    

     public virtual void initPropertiesByData(CharacterData import_data){
        this.data= import_data;
        properties_scale["ATK_plus"] = 1.0f;
        properties_scale["ATK_multi"] = 1.0f;
        properties_scale["DEF_plus"] = 1.0f;
        properties_scale["DEF_multi"] = 1.0f;
        setBarValue(HPBar , data.HP, data.MaxHP);
        setBarValue(EnergyBar , data.energy, data.energy);
     }

    public abstract void die();

    public virtual void setBarValue(UISlider slider,float value,float max_value){
        slider.value = value / max_value;
    }   

    public virtual void onPropertyValueChanged(string property_name){
        switch (property_name)
            {
                case "HP": 
                    setBarValue(HPBar , data.HP, data.MaxHP);
                    if (data.HP <= 0) this.die();
                    break;
                case "energy":
                    setBarValue(EnergyBar , data.energy, data.energy);
                    break;
                default:
                    break;
            }
    }
    public virtual void damageTaken(int value){
        this.modifyHP(-value);
    }
    public virtual void healTaken(int value){
        this.modifyHP(value);
    }

    public virtual void modifyHP(int value){
        this.data.HP += value;
        onPropertyValueChanged("HP");
    }
    public virtual void modifyEnergy(int value){
        this.data.energy += value;
        onPropertyValueChanged("energy");
    }
    public virtual void onClick(){
        if (AbilityController.selected_ability == null) return;
        //已选技能的目标种类和点击角色相同，施放技能
        if (AbilityController.selected_ability.getAbilityTargetType() == this.character_type){
            AbilityController.selected_ability.cast(this);
        }
    }

    public virtual float getFinalAttack(){
        return data.attack * properties_scale["ATK_multi"] + properties_scale["ATK_plus"];
    }
}
