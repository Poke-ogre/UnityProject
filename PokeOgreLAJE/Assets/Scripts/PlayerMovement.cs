using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Camera cam;

    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            agent.isStopped = false;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, mask))
            {
                agent.SetDestination(hit.point);
            }
        }

        if(Input.GetKey(KeyCode.Q))
        {
            agent.isStopped = true;
        }
    }
}
