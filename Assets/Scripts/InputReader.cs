using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public event Action<Vector3> Click;

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButton))
        {
            Click?.Invoke(Input.mousePosition);
        }
    }
}