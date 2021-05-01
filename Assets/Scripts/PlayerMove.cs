using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private ValueHolder valueHolder;

    public float forwardMoveSpeed;
    [SerializeField] private float sideMoveSpeed;

    [SerializeField] private Rigidbody rb;

    //public PlayerMove playerMove;


    public int numberOfAdditionalCubes = 0;

    private void Start()
    {
        valueHolder = ValueHolder.instance;
        forwardMoveSpeed = valueHolder.Speed;
        //playerMove = this;
    }


    private void Update()
    {
        

        //Input
        if (Input.GetKey(KeyCode.A))
            SideMove(1);
        else if (Input.GetKey(KeyCode.D))
            SideMove(-1);
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
       
        rb.velocity = this.transform.forward * forwardMoveSpeed + new Vector3(0.0f, rb.velocity.y, 0.0f);
    }

    private void SideMove(int direction)
    {
        this.transform.Translate(Vector3.left * direction * sideMoveSpeed * Time.deltaTime);
    }
}
