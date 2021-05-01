using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    public static ValueHolder instance;

    [SerializeField] private float moveSpeed;

    public float Speed { get; private set; }

    private void Awake()
    {

        Speed = moveSpeed;


        if (ValueHolder.instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Value holder instance already created");
            Destroy(this.gameObject);
        }
    }
    
}
