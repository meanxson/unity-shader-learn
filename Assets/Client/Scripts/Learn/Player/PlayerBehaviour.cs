using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Mover _mover;
    
    private void Awake()
    {
        _mover = new Mover(GetComponent<Rigidbody>(), _speed);
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _mover.Move(new Vector3(horizontal, 0, vertical));
    }
}