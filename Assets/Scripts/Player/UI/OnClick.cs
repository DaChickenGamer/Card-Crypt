using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    [SerializeField]
    private Texture2D releasedState; // Lets you select the texture for released state
    [SerializeField]
    private Texture2D pressedState;  // Lets you select the texture for pressed state

    private Vector2 hotspot = Vector2.zero;
    [SerializeField]
    private CursorMode cursorMode = CursorMode.Auto; // Sets the cursor mode

    void Start()
    {
        Cursor.SetCursor(releasedState, hotspot, cursorMode); // Sets cursor settings
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Detects with you press left mouse button
        {
            Debug.Log("Clicked");
            Cursor.SetCursor(pressedState, hotspot, cursorMode);
        }
        if (Input.GetMouseButtonUp(0)) // Detects when you unpress left mouse button
        {
            Cursor.SetCursor(releasedState, hotspot, cursorMode);
        }
    }
}