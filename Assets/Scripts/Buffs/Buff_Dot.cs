using UnityEngine;

public class Buff_Dot:BuffBase {
    
    delegate void triggerEvent();
    triggerEvent trigger_event;
    private int interval;
    private int start_time;
    private int id;
    public Buff_Dot(
            int id,
            CharacterBase from,
            CharacterBase to,
            int time, 
            float value,
            int interval){
        this.id = id;
        this.type = "dot";
        this.caster = from;
        this.owner = to;
        this.time = time;
        this.start_time = time;
        this.value = value;
        this.interval = interval;
        trigger_event = new Effect_Damage(from, to, value).cast;
    }
    public override void cast(){
        trigger_event();
    }
    public override void remove(){
        //todo
        //but looks nothing should happen?
        //maybe trigger?
    }

    public override void timePassOne(){
        this.time -= 1;
        int continued_time = this.start_time - this.time;
        if (continued_time % interval == 0){
            this.trigger_event();
        }
        if (time == 0){
            this.remove();
        }
    }

}