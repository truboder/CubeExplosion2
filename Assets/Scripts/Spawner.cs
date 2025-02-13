using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SpawnCubes(Cube cube)
    {
        int minRange = 2;
        int maxRange = 6;

        int cubesCount = Random.Range(minRange, maxRange + 1);

        List<Cube> cubes = new List<Cube>();

        for (int i = 0; i < cubesCount; i++)
        {
            cubes.Add(CreateCube(cube));
        }

        AddForceChildrenCubes(cubes, cube);
        Destroy(cube.gameObject);
    }

    private Cube CreateCube(Cube cube)
    {
        Cube childrenCube = Instantiate(cube, cube.transform.position, cube.transform.rotation);
                
        childrenCube.Reduce();

        return childrenCube;
    }

    private void AddForceChildrenCubes(List<Cube> cubes, Cube primaryCube)
    {
        foreach (Cube cube in cubes)
        {
            cube.AddForce(primaryCube.transform.position, primaryCube.ExplosionForce, primaryCube.ExplosionRadius);
        }
    }
} 
