using System.Collections.Generic;
using UnityEngine;

public class Processer : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _spawnChanceMax = 100;
    [SerializeField] private int _spawnChanceMin = 1;
    [SerializeField] private int _spawnCountMax = 6;
    [SerializeField] private int _spawnCountMin = 2;

    private void OnEnable()
    {
        _rayCaster.Hited += DestroyCube;
    }

    private void OnDisable()
    {
        _rayCaster.Hited -= DestroyCube;
    }

    private void DestroyCube(Cube cube)
    {
        List<Cube> newCubes = new List<Cube>();

        if (CanSpawn(cube))
        {
            newCubes = _spawner.Create(CalculateSpawnCount(), cube);
            Debug.Log("Куб разделился!");
        }
        else
        {
            _exploder.Explode(cube);
        }

        _spawner.DestroyOldCube(cube);
    }

    private bool CanSpawn(Cube cube)
    {
        float spawnChance = cube.SpawnChance;
        int spawnRoll = Random.Range(_spawnChanceMin, _spawnChanceMax + 1);

        return spawnRoll <= spawnChance;
    }

    private int CalculateSpawnCount()
    {
        int spawnCount = Random.Range(_spawnCountMin, _spawnCountMax + 1);
        return spawnCount;
    }
}
