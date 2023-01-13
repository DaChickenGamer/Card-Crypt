using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTesting : MonoBehaviour
{
    private GameObject player;
    private float wait = 0.3f;
    private bool playerspawned=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerspawned)
        {
            if (wait > 0)
            {
                wait -= Time.deltaTime;
            }
            if (wait <= 0)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (player == null)
                {
                    SceneManager.LoadScene(4);
                    playerspawned = true;
                }
            }
        }
    }
}
