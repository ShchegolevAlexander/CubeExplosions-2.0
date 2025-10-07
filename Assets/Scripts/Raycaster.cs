using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> CubeHit;

    private void OnEnable()
    {
        _inputReader.Click += CastRay;
    }

    private void OnDisable()
    {
        _inputReader.Click -= CastRay;
    }

    public void CastRay(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

            if (hitObject.TryGetComponent<Cube>(out Cube cube))
            {
                CubeHit?.Invoke(cube);
            }
        }
    }
}