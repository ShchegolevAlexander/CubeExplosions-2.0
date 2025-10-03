using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3> MouseClick;

    private const int LeftMouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButton))
        {
            MouseClick?.Invoke(Input.mousePosition);
        }
    }
}