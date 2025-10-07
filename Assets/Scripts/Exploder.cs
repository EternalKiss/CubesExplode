using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] ParticleSystem _effect;

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

    public void Explode(Cube oldCube)
    {
        float explosionForce = _explosionForce / oldCube.Size;
        float explosionRadius = _explosionRadius / oldCube.Size;

        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(explosionForce, oldCube.transform.position, explosionRadius);
        }
    }
}
