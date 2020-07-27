using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovimentation : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public bool fixedCamera;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))        
            fixedCamera = !fixedCamera;        

        if(fixedCamera)
            transform.position = player.position + offset;
    }

    public void SetPlayer()
    {
        Debug.LogWarning("Done player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
