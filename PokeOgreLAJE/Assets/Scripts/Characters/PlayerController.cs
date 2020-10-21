using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public LayerMask clickMask;
    public string currentState, currentSkill;

    public Vector3 movePosition;

     public StateMachine stateMachine;

    public Queue<Skill> skillQueue;

    public NavMeshAgent agent;

    //(Basic Attack) Punch

    //(Q) Kick

    //(W)


    //(E) Roll

    //(R)
    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        var skills = new Dictionary<Type, Skill>()
        {
            {typeof(Roll), new Roll(gameObject)}
        };

        var states = new Dictionary<Type, BaseState>()
        {
            {typeof(FreeState), new FreeState(gameObject, skills)},
            {typeof(CastingState), new CastingState(gameObject) }
        };
        stateMachine = GetComponent<StateMachine>();
        stateMachine.SetStates(states);
        skillQueue = new Queue<Skill>();
    }

    public IEnumerator WaitToDequeueSkill(float time)
    {
        yield return new WaitForSeconds(time);        
        stateMachine.OnSkillFinish();
        skillQueue.Dequeue();
        if(skillQueue.Count > 0)        
            skillQueue.Peek().skillCooldown.CastSkill(); 
    }
}
