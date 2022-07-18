using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    // Start is called before the first frame update
    void Start()
    {
        ModuleManager.GetModule<PlayerEventManager>().OnMove += Move;
    }

    public void Move(Vector3 direction, MovementState state)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(direction.x * _multiplier, 0, direction.z));
    }
}
