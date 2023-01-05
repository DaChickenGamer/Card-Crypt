using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    [SerializeField]
    private Texture2D releasedState;
    [SerializeField]
    private Texture2D pressedState;

private Vector2 hotspot = Vector2.zero;
    [SerializeField]
    private CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        Cursor.SetCursor(releasedState, hotspot, cursorMode);
    }

    private void Update()
    {
        // You don't need to reassign these variables in every frame
        //PlayerSpawner.PlayerVarible = PlayerSpawner.PlayerVarible;
        //Health._currentHealth = Health._currentHealth;

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(pressedState, hotspot, cursorMode);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(releasedState, hotspot, cursorMode);
        }
    }
}