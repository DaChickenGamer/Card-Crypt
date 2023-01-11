using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneTeleporter : MonoBehaviour
{

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
            Debug.Log("New Scene");
            SceneManager.LoadScene(ChangeScene.PlayerScene+1);
            ChangeScene.PlayerScene++;
            }
        }
}
