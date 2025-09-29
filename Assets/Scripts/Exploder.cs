using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Cube oldCube, List<Cube> newCubes)
    {
        float explosionForce = _explosionForce / oldCube.Size;
        float explosionRadius = _explosionRadius / oldCube.Size;

        foreach (Cube cube in newCubes)
        {
            if(cube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explosionForce, oldCube.transform.position, explosionRadius);
            }
        }
    }
}
