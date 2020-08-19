using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkController : EntityEventListener<IPlayerState>
{
    private PlayerController playerController;

    public override void Attached()
    {
        state.SetTransforms(state.Transform, transform);
        state.SetAnimator(gameObject.GetComponentInChildren<Animator>());
        playerController = gameObject.GetComponent<PlayerController>();
    }


    public override void SimulateController()
    {
        if (playerController.clickPos != Vector3.zero)
        {
            IClickToMoveCommandInput input = ClickToMoveCommand.Create();
            input.click = playerController.clickPos;
            entity.QueueInput(input);
            playerController.clickPos = Vector3.zero;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

        }

        if (Input.GetKeyDown(KeyCode.E))
        {

        }

        if (Input.GetKeyDown(KeyCode.R))
        {

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
            playerController.SetTarget(cmd.Input.click);
            cmd.Result.position = transform.position;
        }
    }

    public void doThis(BoltEntity b)
    {

    }
}
