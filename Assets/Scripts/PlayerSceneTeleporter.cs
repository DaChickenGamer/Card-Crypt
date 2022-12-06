using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneTeleporter : MonoBehaviour
{
    public int sceneID;
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(sceneID);
            }
        }
}
