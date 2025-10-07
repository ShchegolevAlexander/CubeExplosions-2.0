using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ExplodeEffector _explodeEffector;

    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 0.5f;

    public void Explode(Rigidbody[] rigidbodies, float forceMultiplier)
    {
        if (rigidbodies == null && rigidbodies.Length == 0)
            return;

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            if (rigidbody == null)
                continue;

            rigidbody.AddExplosionForce(_explosionForce * forceMultiplier, transform.position, _explosionRadius, _upwardModifier, ForceMode.Impulse);
        }
    }

    public void ExpodeWithEffect(Cube cube)
    {
        float cubeSize = cube.transform.localScale.x;
        float explosionForce = _explosionForce / cubeSize;
        float explosionRadius = _explosionRadius * cubeSize;

        _explodeEffector.Explode(cube.transform.position);

        Collider[] cubes = Physics.OverlapSphere(cube.transform.position, explosionRadius);

        foreach (Collider nearbyCubes in cubes)
        {
            Rigidbody rigidbody = nearbyCubes.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, cube.transform.position, explosionRadius, _upwardModifier, ForceMode.Impulse);
            }
        }
    }
}