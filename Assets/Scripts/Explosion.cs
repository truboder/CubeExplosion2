using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explode(Cube cube)
    {
        Collider[] hitsCubes = Physics.OverlapSphere(cube.transform.position, cube.ExplosionRadius);

        foreach (Collider hitCube in hitsCubes)
        {
            if (hitCube.attachedRigidbody != null)
            {
                hitCube.attachedRigidbody.AddExplosionForce(cube.ExplosionForce, cube.transform.position, cube.ExplosionRadius);
                Destroy(cube.gameObject);
            }
        }
    }
}
