using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _halver = 2f;

    public Cube[] Spawn(Vector3 position, Vector3 scale, int minCount, int maxCount, ColorChanger colorChanger)
    {
        int count = Random.Range(minCount, maxCount + 1);
        Vector3 newScale = scale / _halver;
        Cube[] cubes = new Cube[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = new Vector3
                (
                Random.Range(-newScale.x / _halver, newScale.x / _halver),
                Random.Range(-newScale.y / _halver, newScale.y / _halver),
                Random.Range(-newScale.z / _halver, newScale.z / _halver)
                );

            Cube newCube = Instantiate(_cubePrefab, position + offset, Quaternion.identity);
            newCube.transform.localScale = newScale;

            Cube cube = newCube;

            if (cube != null)
            {
                cube.SetColorChanger(colorChanger);

                if (cube.ColorChanger != null)
                {
                    cube.ChangeColor();
                }
            }

            cubes[i] = cube;
        }

        return cubes;
    }
}