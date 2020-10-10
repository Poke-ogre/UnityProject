using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CastingState : BaseState
{
    private NavMeshAgent agent;
    private PlayerController player;
    private bool isCasting = true;

    public CastingState(GameObject obj) : base(obj)
    {
        agent = obj.GetComponent<NavMeshAgent>();
        player = obj.GetComponent<PlayerController>();
    }

    public override Type Tick()
    {
        if(!isCasting)
        {
            isCasting = true;
            Debug.Log("Stop the cast");
            return typeof(FreeState);
        }

        return null;
    }

    public void CastFinished() => isCasting = false;
    
}
