using UnityEngine;

public class Ability_meleeAttack : AbilityBase {

    public Ability_meleeAttack(CharacterBase owner, int value){
        this.id = 1;
        this.cost = 0;
        this.costType = "none";
        this.abilityName = "Melee";
        this.description = "Deal X damage to a enemy";
        this.owner = owner;
        this.value = value;
        this.type = "melee";
        this.targetType = "enemy";
    }

    public override void cast(CharacterBase target){
        new Effect_Damage(owner, target, owner.getFinalAttack()).cast();
    }

    public override void updateDescription(){
        this.description = "Deal X damage to a enemy";
    }
    
    public override void onClick(){
        //没有选择技能
        if (AbilityController.selected_ability == null){
            AbilityController.selected_ability = this;
            this.selectedThis();
        }else{
            //已选择本技能
            if (AbilityController.selected_ability == this){
                AbilityController.selected_ability = null;
                this.cancelSeleted();
            //已经选择了其他技能，改为选该技能
            }else{
                AbilityController.selected_ability.cancelSeleted();
                AbilityController.selected_ability = this;
                this.selectedThis();
            }
        }
    }
}