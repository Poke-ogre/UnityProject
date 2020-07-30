using System;
using UnityEngine;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;
using TMPro;
using System.Text.RegularExpressions;

public class Menu : GlobalEventListener
{

    TextMeshProUGUI room;
    public string matchName;

    private void Start()
    {
        room = GameObject.FindGameObjectWithTag("Room").GetComponent<TextMeshProUGUI>();
    }

    public void StartServer()
    {
        matchName = room.text;

        if (matchName != null && matchName != "")
        {
            BoltLauncher.StartServer();
        }
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone()
    {
        
        if(BoltNetwork.IsServer)
        {
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
