using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BossMovimentation : MonoBehaviour
{

    public Transform playerChasing;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerChasing.position);
    }
}
