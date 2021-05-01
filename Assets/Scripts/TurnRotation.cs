using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRotation : MonoBehaviour
{
    
    [SerializeField] private float rotationAngle = 90f;

    [SerializeField] PlayerMove playerMoveHolder;

    [SerializeField] private float startPlayerYRotation;
    [SerializeField] private float targetRotation;

    [Range(0.1f, 1f)]
    [SerializeField] private float speedCoef = 1;//Speed when turn

    
    private Transform player;

    private ValueHolder valueHolder;
    private float playerSpeed;


    private void Start()
    {
        valueHolder = ValueHolder.instance;

        playerSpeed = valueHolder.Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            
            playerMoveHolder.forwardMoveSpeed = 0f;
            startPlayerYRotation = other.transform.parent.transform.eulerAngles.y;
            
            targetRotation = startPlayerYRotation + rotationAngle;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.transform.parent.CompareTag("Player"))
        {
            
            player = other.transform.parent;
            if (player.eulerAngles.y != targetRotation)
                player.RotateAround(this.gameObject.transform.position, Vector3.up, rotationAngle * (Time.deltaTime * (speedCoef)));
            
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            //Fix i dnt sure if need
            player.rotation = Quaternion.Euler(0f, targetRotation, 0f);


            playerMoveHolder.forwardMoveSpeed = playerSpeed;
        }
    }
}
