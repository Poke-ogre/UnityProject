
using UnityEngine;

//[BoltGlobalBehaviour(BoltNetworkModes.Server, "Main")]
public class ClickToMoveNetworkCallbacks : Bolt.GlobalEventListener
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
        return BoltNetwork.Instantiate(BoltPrefabs.Player, respawn.transform.position, Quaternion.identity);
    }
}