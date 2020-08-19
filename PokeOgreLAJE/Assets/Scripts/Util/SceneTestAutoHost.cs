using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Bolt.Matchmaking;

public class SceneTestAutoHost : GlobalEventListener
{
    public string scene;
    public void Start()
    {
        // BoltLauncher.Shutdown();
        BoltLauncher.StartServer();        
    }

    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            BoltMatchmaking.CreateSession(sessionID: "", sceneToLoad: "DemoScene");
        }
    }
}
