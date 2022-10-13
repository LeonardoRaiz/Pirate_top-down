using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    private void Update() {
        transform.position = Input.mousePosition;
    }
}
