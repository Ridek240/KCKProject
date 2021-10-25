using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    private Rigidbody rb;
    private float Move_Speed = 10f;
    private float Sprint_Move;
    private Vector3 moveDir;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test");
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveZ = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveZ = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, 500f, 0f));
            Debug.Log("skok");
            //rb.MovePosition(transform.position + new Vector3(0,10f,0));
        }
        
        moveDir = new Vector3(moveX, -0.5f, moveZ).normalized;
        //rb.AddForce( moveDir * Move_Speed);
        //rb.MovePosition(transform.position + moveDir);
        rb.velocity = moveDir * Move_Speed;
    }

}
