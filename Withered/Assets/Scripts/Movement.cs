using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform bottomTransform;
    private RaycastHit2D grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int everyMaskExcept =~ LayerMask.GetMask("Player");
        grounded = Physics2D.Raycast(bottomTransform.position, transform.up * -1, 0.2f, everyMaskExcept);
        //TODO auslagern erfordert Einstellungen 
        if (Input.GetKey(KeyCode.D)) move(Vector3.right);
        if (Input.GetKey(KeyCode.A)) move(Vector3.left);
        if (Input.GetKey(KeyCode.W) && grounded.transform != null) move(Vector3.up);
        if (Input.GetKey(KeyCode.S)) move(Vector3.down);
    }

    public void move(Vector3 direction)
    {
        if(direction.Equals(Vector3.up)) GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
        else GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }
}
