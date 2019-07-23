using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffBase
{
    protected int time;
    protected CharacterBase caster;
    protected CharacterBase owner;
    protected string type;
    protected float value;
    public abstract void cast();
    public abstract void remove();
    public abstract void timePassOne();


}
