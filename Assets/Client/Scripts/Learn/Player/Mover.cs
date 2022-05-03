using UnityEngine;

public class Mover
{
    private readonly Rigidbody _rigidbody;
    private readonly float _speed;

    public Mover(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void Move(Vector3 nextStep)
    {
        _rigidbody.AddForce( nextStep * Time.fixedDeltaTime * _speed, ForceMode.Impulse);
    }
}
