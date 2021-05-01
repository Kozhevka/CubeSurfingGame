using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Transform playerCenterPosition;

    [SerializeField] private Rigidbody thisRb;

    [SerializeField] private float smoothSpeed;

    private void Update()
    {
        
        //this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, smoothSpeed * Time.deltaTime);
        this.transform.LookAt(playerCenterPosition);
    }
    private void FixedUpdate()
    {
        thisRb.MovePosition(targetPosition.position);
    }
}
