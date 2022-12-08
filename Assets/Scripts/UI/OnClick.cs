using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    [SerializeField]
    private Texture2D ReleasedState;
    [SerializeField]
    private Texture2D PressedState;

    private Vector2 _hotspot=Vector2.zero;
    [SerializeField]
    private CursorMode _cursorMode=CursorMode.Auto;
    void Start()
    {
        Cursor.SetCursor(ReleasedState, _hotspot, _cursorMode);
    }
    private void Update()
    {
        PlayerSpawner.PlayerVarible = PlayerSpawner.PlayerVarible;
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(PressedState, _hotspot, _cursorMode);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(ReleasedState, _hotspot, _cursorMode);
        }
    }
}
