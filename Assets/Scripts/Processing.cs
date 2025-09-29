using System.Collections.Generic;
using UnityEngine;

public class Processing : MonoBehaviour
{
    [SerializeField] private MouseClickReader _mouseClickInput;
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    private int _spawnChanceMax = 100;
    private int _spawnChanceMin = 1;
    private int _spawnCountMax = 6;
    private int _spawnCountMin = 2;

    private void OnEnable()
    {
        _rayCaster.Hited += CubeDestroy;
    }

    private void OnDisable()
    {
       _rayCaster.Hited -= CubeDestroy;
    }

    private void CubeDestroy(Cube cube)
    {
        List<Cube> newCubes = new List<Cube>();

        if(CanSpawn(cube))
        {
            newCubes = _spawner.Create(CalculateSpawnCount(), cube);
            Debug.Log("Куб разделился!");
        }

        _spawner.DestroyOldCube(cube);
    }

    private bool CanSpawn(Cube cube)
    {
        float spawnChance = cube.SpawnChance;
        int spawnRoll = Random.Range(_spawnChanceMin, _spawnChanceMax);

        return spawnRoll <= spawnChance;
    }

    private int CalculateSpawnCount()
    {
        int spawnCount = Random.Range(_spawnCountMin, _spawnCountMax++);
        return spawnCount;
    }
}
