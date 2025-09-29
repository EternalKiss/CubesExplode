using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Transactions;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explosion(Cube oldCube, List<Cube> newCubes)
    {
        foreach (Cube cube in newCubes)
        {
            if(cube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, oldCube.transform.position, _explosionRadius);
            }
        }
    }

    public void Explode(Cube oldCube)
    {

        float explosionForce = _explosionForce / oldCube.Size;
        float explosionRadius = _explosionRadius / oldCube.Size;

        foreach (Rigidbody rigidbody in GetExplodableObjects(oldCube, explosionRadius))
        {
            rigidbody.AddExplosionForce(explosionForce, oldCube.transform.position, explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube oldCube, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> cubesRigidBodies = new();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                cubesRigidBodies.Add(hit.attachedRigidbody);
            }
        }

        return cubesRigidBodies;
    }
}
