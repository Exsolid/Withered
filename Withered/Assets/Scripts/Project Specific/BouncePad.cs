using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] protected LayerMask _playerMask;
    private RaycastHit2D _grounded;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1<<collision.gameObject.layer).Equals(_playerMask))
        {
            _grounded = Physics2D.Raycast(collision.gameObject.GetComponent<MovementBase>().GroundedTransform.position, transform.up * -1, 0.01f, (1 << gameObject.layer));
            if(_collider.Equals(_grounded.collider))
            {
                collision.gameObject.GetComponent<Movement2D>().MoveWithStrength(Vector3.up, Vector3.one * _multiplier);
            }
        }
    }
}
