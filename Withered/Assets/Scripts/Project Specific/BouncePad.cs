using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private float strength;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            collision.gameObject.GetComponent<MovementTwoD>().moveWithStrength(Vector3.up, strength);
            collision.gameObject.GetComponent<MovementTwoD>().moveWithStrength(Vector3.up, strength);
        }
    }
}
