using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> CubeHit;

    private void OnEnable()
    {
        _inputReader.MouseClick += CastRay;
    }

    private void OnDisable()
    {
        _inputReader.MouseClick -= CastRay;
    }

    public void CastRay(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            Cube cube;

            if (hitObject.TryGetComponent<Cube>(out cube))
            {
                CubeHit?.Invoke(cube);
            }
        }
    }
}