using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingBlock : MonoBehaviour
{
    public static AddingBlock instance;

    [SerializeField] private GameObject avatarObj;
    [SerializeField] private Rigidbody avatarRb;

    

    [SerializeField] PlayerMove playerMoveScript;
 
    public List<GameObject> additionalBlockList;
    [SerializeField] private int additionalBlockInt;
    

    [SerializeField] Rigidbody thisRb;

    [SerializeField] private GameObject lowestCubeTransform;

    [SerializeField] BoxCollider cubeSampleCollider;
    private float cubeSideSize;

    private void Awake()
    {
        if(AddingBlock.instance ==null)
            instance = this;
        else
        {
            Debug.LogError("AddingBlock instance already exist");
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        cubeSideSize = cubeSampleCollider.size.x;
    }

    private void OnEnable()
    {
        additionalBlockInt = additionalBlockList.Count;
    }

    public void AddBlock(GameObject additionalBlock)
    {


       
        additionalBlockList.Add(additionalBlock);
        additionalBlockInt = additionalBlockList.Count;

        this.transform.position += new Vector3(0f, cubeSideSize, 0f);


        lowestCubeTransform.transform.localPosition = new Vector3(0f, (-cubeSideSize * additionalBlockInt), 0f);
        thisRb.centerOfMass = lowestCubeTransform.transform.localPosition;


        additionalBlock.transform.parent = this.transform;

        
        
        additionalBlock.transform.position = lowestCubeTransform.transform.position;

        
        
    }

    

    public void RemoveBlock(GameObject removingBlock)
    {
        


        additionalBlockList.Remove(removingBlock);

        removingBlock.transform.parent = null;

        additionalBlockInt = additionalBlockList.Count;
        lowestCubeTransform.transform.localPosition = new Vector3(0f, (cubeSideSize * -additionalBlockInt), 0f);
        thisRb.centerOfMass = lowestCubeTransform.transform.localPosition;

        if (additionalBlockList.Count == 0)
            GameOverFunctions();
        
    }

    private void GameOverFunctions()
    {
        avatarRb.constraints = RigidbodyConstraints.None;
        avatarRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        avatarRb.AddForce(Vector3.forward * 5, ForceMode.Impulse);

        lowestCubeTransform.SetActive(false);
        playerMoveScript.enabled = false;


    }
    

    







    
}
