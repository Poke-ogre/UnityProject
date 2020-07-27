using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMoveController : EntityEventListener<IPlayerState>
{
    public LayerMask mask;

    public override void Attached()
    {
        state.SetTransforms(state.Transform, transform);
        state.SetAnimator(gameObject.GetComponentInChildren<Animator>());       
    }


    public override void SimulateController()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IClickToMoveCommandInput input = ClickToMoveCommand.Create();
            input.click = Click();
            entity.QueueInput(input);
        }
    }

    public override void ExecuteCommand(Command command, bool resetState)
    {
        ClickToMoveCommand cmd = (ClickToMoveCommand)command;

        if (resetState)
        {
            //owner has sent a correction to the controller
            transform.position = cmd.Result.position;
        }
        else
        {
            if (cmd.Input.click != Vector3.zero)
            {
                
                gameObject.SendMessage("SetTarget", cmd.Input.click);
                Debug.Log("sent message");
            }

            cmd.Result.position = transform.position;
        }
    }

    private Vector3 Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
