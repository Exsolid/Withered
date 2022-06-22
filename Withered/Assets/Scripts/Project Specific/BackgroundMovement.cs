using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        ModuleManager.get<PlayerEventmanager>().move += move;
    }

    public void move(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(direction.x * multiplier, 0, direction.z));
    }
}
