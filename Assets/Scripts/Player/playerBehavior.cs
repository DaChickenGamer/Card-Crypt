using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour
{
    
    public GameObject Player;
    void Update()
    {
        
        // Testing Input To Take Damage
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerTakeDmg(20);
            Debug.Log("Health: " + GameManager.gameManager.healthAmount.playerHealthAmount);
        }
        // Testing Input To Heal
        if (Input.GetKeyDown(KeyCode.G))
        {

            PlayerHeal(10);
            Debug.Log("Health: " + GameManager.gameManager.healthAmount.playerHealthAmount);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Health: " + GameManager.gameManager.healthAmount.playerHealthAmount);
        }
        if (Player != null)
        {
            if (GameManager.gameManager.healthAmount.playerHealthAmount <= 0)
            {
                Destroy(Player);
                SceneManager.LoadScene(3);
            }
        }
    }
    private void PlayerTakeDmg(float dmg)
    {
        // Applies the damage function (subracting health)
        GameManager.gameManager.healthAmount.Dmg(dmg);
    }
    private void PlayerHeal(float healing)
    {
        // Applies the healing function (adding health)
        GameManager.gameManager.healthAmount.Heal(healing);
    }
}
