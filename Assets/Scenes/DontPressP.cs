using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class DontPressP : MonoBehaviour
{
    bool crash;
    int crashing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P)&&Input.GetKey(KeyCode.Escape))
        {
            crash = true;
        }
        while (crash)
        {
            Utils.ForceCrash(ForcedCrashCategory.Abort);
        }
    }
}
