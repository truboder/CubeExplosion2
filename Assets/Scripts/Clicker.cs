using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Spawner _spawner;

    private int _mousseButtonTrigger = 0;

    private Explosion _explosion = new Explosion();

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        float maxDistance = Mathf.Infinity;

        if (Input.GetMouseButtonDown(_mousseButtonTrigger))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, _layerMask))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (cube.CanSplit())
                    {
                        _spawner.SpawnCubes(cube);
                    }
                    else
                    {
                        _explosion.Explode(cube);
                    }
                }
            }
        }
    }
}
