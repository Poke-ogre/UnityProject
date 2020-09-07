using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAnimController: MonoBehaviour
{
    public PlayerController player;

    public void PauseAgent()
    {
        player.agent.isStopped = true;
    }
    public void ResumeAgent()
    {
        player.playerState = PlayerController.PlayerStates.FREE;
        player.agent.isStopped = false;
    }
}
