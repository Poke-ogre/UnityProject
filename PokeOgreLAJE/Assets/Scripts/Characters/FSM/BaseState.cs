using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseState
{
    protected GameObject gameObject;
    protected Transform transform;

    public BaseState(GameObject obj)
    {
        this.gameObject = obj;
        this.transform = gameObject.transform;
    }
    
    public abstract Type Tick();
}
