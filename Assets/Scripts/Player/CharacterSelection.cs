using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
        public void Melee()
        {
            PlayerSpawner.playerType += 1;
        ChangeScene.PlayerScene++;
    }
        public void Ranged()
        {
            PlayerSpawner.playerType += 2;
        ChangeScene.PlayerScene++;
    }
        public void Magic()
        {
            PlayerSpawner.playerType += 3;
        ChangeScene.PlayerScene++;
    }
}
