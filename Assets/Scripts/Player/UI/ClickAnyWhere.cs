using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnyWhere : MonoBehaviour
{
    [SerializeField]
        GameObject objectToDestroy;

    public void DestroyGameObject()
    {
        Destroy(objectToDestroy);
    }
    public void Update()
    {
        if (Input.anyKeyDown) // Checks for any input
        {
            Destroy(objectToDestroy); // Destorys screen and moves on
            Debug.Log("Countined");
        }
    }
}
