using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 100;
    [SerializeField] private float _explosionForce = 700;

    private float _splitChance = 1.0f;
    private float _splitChanceMaxRange = 1.0f;

    private Rigidbody _rigidbody;
    private Coloring _coloring = new Coloring();

    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _coloring.SetRandomColor(GetComponent<Renderer>());
    }

    public void ChangeStats()
    {
        float reduction = 2.0f;

        transform.localScale /= reduction;
        _splitChance /= reduction;

        float _scaler = 1.5f;

        _explosionForce *= _scaler;
        _explosionRadius *= _scaler;
    }

    public void AddForce(Vector3 position, float force, float radius)
    {
        _rigidbody.AddExplosionForce(force, position, radius);
    }

    public bool CanSplit() => Random.Range(0, _splitChanceMaxRange) <= _splitChance;
}
