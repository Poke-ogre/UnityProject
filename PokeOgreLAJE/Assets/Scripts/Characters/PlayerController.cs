using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public NavMeshAgent agent;

    public LayerMask mask;
    private GameObject clickFeedback;

    public Vector3 clickPos;
    public bool castQ, castW, castE, castR;

    public enum PlayerStates { FREE, CASTING };
    public PlayerStates playerState = PlayerStates.FREE;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState == PlayerStates.FREE)
        {
            float speedPercent = agent.velocity.magnitude / agent.speed;
            anim.SetFloat("playerSpeed", speedPercent);

            if (Input.GetMouseButtonDown(1))
            {
                clickPos = Click();
                if (agent.isStopped)
                    agent.isStopped = false;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                playerState = PlayerStates.CASTING;
                anim.SetTrigger("poke");
            }
            if (Input.GetKey(KeyCode.W))
            {
                playerState = PlayerStates.CASTING;
                anim.SetTrigger("throw");
            }
            if (Input.GetKey(KeyCode.E))
            {
                playerState = PlayerStates.CASTING;
                anim.SetTrigger("Poke");
            }
            if (Input.GetKey(KeyCode.R))
            {
                playerState = PlayerStates.CASTING;
                anim.SetTrigger("charm");
            }

            //consmetic interactions
            if (Input.GetKey(KeyCode.Alpha1))
            {
                anim.Play("Taunt Point");
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                anim.Play("Taunt Dance");
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {

            }
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
