using System;
using System.Collections;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    [SerializeField] private int _minNewCubes = 2;
    [SerializeField] private int _maxNewCubes = 6;

    private float _splitChance = 1f;
    private int _halver = 2;
    private float _explosionForceMultuplier = 1f;

    private void OnEnable()
    {
        _raycaster.CubeHit += Hit;
    }

    private void OnDisable()
    {
        _raycaster.CubeHit -= Hit;
    }

    private void Hit(Cube cube)
    {
        float random = UnityEngine.Random.value;

        if (random <= _splitChance)
        {
            _splitChance /= _halver;

            if (_spawner != null && cube.ColorChanger != null)
            {
                Cube[] newCubes = _spawner.Spawn(cube.transform.position, cube.transform.localScale, _minNewCubes, _maxNewCubes, cube.ColorChanger);

                if (_exploder != null)
                {
                    Rigidbody[] newRigidbodies = new Rigidbody[newCubes.Length];

                    for (int i = 0; i < newCubes.Length; i++)
                    {
                        newRigidbodies[i] = newCubes[i].Rigidbody;
                    }

                    _exploder.Explode(newRigidbodies, cube.transform.localScale.x * _explosionForceMultuplier);
                }
            }
        }
        else
        {
            _exploder.ExpodeWithEffect(cube);
        }

        if (cube != null)
        {
            Destroy(cube.gameObject);
        }
    }
}