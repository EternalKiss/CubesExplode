using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Cube oldCube, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidBody))
            {
                rigidBody.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
            }
        }
    }

    public void Explode(Cube oldCube)
    {
        float explosionRadius = _explosionRadius / oldCube.Size;
        float explosionForce = _explosionForce / oldCube.Size;

        foreach (Rigidbody rigidbody in GetExplodableObjects())
        {
            rigidbody.AddExplosionForce(explosionForce, oldCube.transform.position, explosionRadius);
        }

    }
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
