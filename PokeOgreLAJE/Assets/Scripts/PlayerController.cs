using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    Animator anim;
    NavMeshAgent agent;
    public LayerMask mask;
    private GameObject clickFeedback;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("playerSpeed", speedPercent);

        if (Input.GetKey(KeyCode.Q))
        {
            anim.Play("Poke");
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.Play("SlowCast");
        }
        if (Input.GetKey(KeyCode.E))
        {
            anim.Play("Poke");
        }
        if (Input.GetKey(KeyCode.R))
        {
            anim.Play("CharmCast");
        }

    }
    public Vector3 Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50, mask))
        {
            GameObject obj = Pooler.Singleton.InstantiateFromPool("ClickFeedback");
            Pooler.Singleton.DestroyToPoolWithTimer("ClickFeedback", obj, 1f);
            obj.transform.position = hit.point;
            return hit.point;
        }

        return Vector3.zero;
    }

    public void SetTarget(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
