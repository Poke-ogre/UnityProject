﻿
using UnityEngine;

[BoltGlobalBehaviour(BoltNetworkModes.Server, "DemoScene")]
public class GameNetworkCallbacks : Bolt.GlobalEventListener
{
    [System.Obsolete]
    public override void SceneLoadLocalDone(string scene)
    {
        var player = InstantiateEntity();
        player.TakeControl();
    }

    [System.Obsolete]
    public override void SceneLoadRemoteDone(BoltConnection connection)
    {
        var player = InstantiateEntity();
        player.AssignControl(connection);
    }

    private BoltEntity InstantiateEntity()
    {
        GameObject[] respawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        var respawn = respawnPoints[Random.Range(0, respawnPoints.Length)];
        BoltEntity player = BoltNetwork.Instantiate(BoltPrefabs.Player, respawn.transform.position, Quaternion.identity);
        Camera.main.GetComponent<CameraMovimentation>().SetPlayer();
        return player;
    }
}