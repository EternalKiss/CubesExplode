using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _sizeScaleDown = 2f;
    private float _chanceScaleDown = 2f;

    public List<Cube> Create(int spawnCount, Cube cube)
    {
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < spawnCount; i++)
        {
            Cube newCube = InitializeCube(Instantiate(cube));
            newCubes.Add(newCube);
        }    

        return newCubes;
    }
    private Cube InitializeCube(Cube cube)
    {
        float cubeNewSize = cube.Size / _sizeScaleDown;
        float newSpawnChance = cube.SpawnChance / _chanceScaleDown;
        Vector3 newCubePosition = cube.transform.position;

        cube.Initialize(cubeNewSize, newSpawnChance, newCubePosition);

        return cube;
    }

    public void DestroyOldCube(Cube oldCube)
    {
        Destroy(oldCube.gameObject);
    }
}
