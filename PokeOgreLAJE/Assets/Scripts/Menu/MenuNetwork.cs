using System;
using UnityEngine;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;
using TMPro;
using UnityEngine.UI;

public class MenuNetwork : GlobalEventListener
{
    public GameObject main, networkOption, sessionList, settings, buttonHost, viewport, roomPrefab;

    public TextMeshProUGUI roomName;
    public string sceneToLoad;    

    private void Start()
    {
        main.SetActive(true);
        networkOption.SetActive(false);
        sessionList.SetActive(false);
        settings.SetActive(false);
    }



    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
            BoltMatchmaking.CreateSession(sessionID: roomName.text, sceneToLoad: sceneToLoad);
        else
            SessionListUpdated(BoltNetwork.SessionList);
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        base.SessionListUpdated(sessionList);
        //float offset = 0;
        foreach (var session in sessionList)
        {
            UdpSession matchSession = session.Value as UdpSession;
            GameObject obj = Instantiate(original: roomPrefab, parent: viewport.transform);            
            TextMeshProUGUI name = obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (name) name.SetText(matchSession.HostName);
            obj.GetComponentInChildren<Button>().onClick.AddListener(() => JoinSession(matchSession.HostName));

        }
    }

    public void JoinSession(string name) => BoltMatchmaking.JoinSession(name);
    
    public void HostButton() => BoltLauncher.StartServer();        
    
    public void JoinButton() => BoltLauncher.StartClient();
   
    public void ShutdownBolt() => BoltLauncher.Shutdown();
    
}
