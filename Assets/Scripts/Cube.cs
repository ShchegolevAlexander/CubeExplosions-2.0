using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public ColorChanger ColorChanger => _colorChanger;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        if (_colorChanger != null && _renderer != null)
        {
            _colorChanger.ChangeColor(_renderer);
        }
    }

    public void SetMass(float mass)
    {
        if (_rigidbody != null)
        {
            _rigidbody.mass = mass;
        }
    }

    public void SetColorChanger(ColorChanger colorChanger)
    {
        _colorChanger = colorChanger;
    }
}