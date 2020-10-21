using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Roll : Skill
{
    private GameObject player;

    public Roll(GameObject obj) : base()
    {
        this.player = obj;
        //skillCooldown.Initialize(this);
    }

    public override void CastSkill() => playerController.StartCoroutine(playerController.WaitToDequeueSkill(animation.length));
    
}
