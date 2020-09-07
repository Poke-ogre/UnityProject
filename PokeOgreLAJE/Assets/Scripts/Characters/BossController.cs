using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public enum OgreStates {STAGE1, STAGE2, STAGE3}

    public OgreStates ogreState = OgreStates.STAGE1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(ogreState)
        {
            case OgreStates.STAGE1:

                break;
        }
    }
}
