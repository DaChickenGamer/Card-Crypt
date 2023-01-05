using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
        public void Melee()
        {
            PlayerSpawner.PlayerVarible += 1;
        ChangeScene.PlayerScene++;
    }
        public void Ranged()
        {
            PlayerSpawner.PlayerVarible += 2;
        ChangeScene.PlayerScene++;
    }
        public void Magic()
        {
            PlayerSpawner.PlayerVarible += 3;
        ChangeScene.PlayerScene++;
    }
}
