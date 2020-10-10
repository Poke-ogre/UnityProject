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
        if (playerController.movePosition != Vector3.zero)
        {
            IClickToMoveCommandInput input = ClickToMoveCommand.Create();
            input.click = playerController.movePosition;
            entity.QueueInput(input);
            playerController.movePosition = Vector3.zero;
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
            FreeState s = (FreeState)playerController.stateMachine.CurrentState;
            s.SetTarget(cmd.Input.click);
            cmd.Result.position = transform.position;
        }
    }

    public void doThis(BoltEntity b)
    {

    }
}
