using System;
using UnityEngine;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;

public class Menu : Bolt.GlobalEventListener
{
    public void StartServer()
    {
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone()
    {
        
        if(BoltNetwork.IsServer)
        {
            string matchName = "Test xoxo";

            BoltMatchmaking.CreateSession(sessionID: matchName, sceneToLoad: "Main");
        }
    }


    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach(var session in sessionList)
        {
            UdpSession matchSession = session.Value as UdpSession;

            if(matchSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(matchSession);
            }
        }
    }
}
