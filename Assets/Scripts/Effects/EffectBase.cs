using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectBase 
{
    protected CharacterBase caster;
    protected CharacterBase target;
    protected float value;
    public abstract void cast();


}
