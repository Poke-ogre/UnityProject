
using UnityEngine;

[BoltGlobalBehaviour(BoltNetworkModes.Server, "Main", "DemoScene")]
public class GameNetworkCallbacks : Bolt.GlobalEventListener
{

    public Transform spawn;

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
        spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
        BoltEntity player = BoltNetwork.Instantiate(BoltPrefabs.Player, spawn.position, Quaternion.identity);
        Camera.main.GetComponent<CameraMovimentation>().SetPlayer();
        return player;
    }
}