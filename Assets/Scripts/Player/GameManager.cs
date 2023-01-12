using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; set; }
    // Sets Max Health
    public Health _playerHealth = new Health(100, 100);

    public gameState State;

    void Awake()
    {
        // Turns off if there is another Game Mananger.
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }
    public void UpdateGameState(gameState newState)
    {
        State = newState;
        switch (newState)
        {
            
        }
    }
}

public enum gameState
{
    PauseMenu,
    Countine,
}