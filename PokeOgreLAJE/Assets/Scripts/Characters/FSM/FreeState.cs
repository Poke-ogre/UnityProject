using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FreeState : BaseState
{
    private new GameObject gameObject;
    private PlayerController playerController;
    private Transform tranform;
    private NavMeshAgent agent;
    private Animator anim;
    private LayerMask clickMask;
    private Dictionary<Type, Skill> skills;    
    public FreeState(GameObject obj, Dictionary<Type, Skill> skills) : base(obj)
    {
        this.gameObject = obj;
        this.tranform = obj.transform;
        this.agent = obj.GetComponent<NavMeshAgent>();
        this.anim = obj.GetComponentInChildren<Animator>();
        this.playerController = obj.GetComponent<PlayerController>();
        this.clickMask = playerController.clickMask;
        this.skills = skills;
    }

    public override Type Tick()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speed", speedPercent);

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 destination = Util.Click(50, clickMask);
            if (destination != Vector3.zero)
            {
                playerController.movePosition = destination;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //skills[typeof(Kick)].OnSkillPressed();
            return typeof(CastingState);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //skills[typeof(Roll)].OnSkillPressed();
            return typeof(CastingState);
        }

        return null;
    }

    public void SetTarget(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
}
