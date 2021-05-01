using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheker : MonoBehaviour
{
    private AddingBlock addingBlockScript;

    [SerializeField] GameObject parentGameObject;
    [SerializeField] bool blockIsChild = false;
    [SerializeField] bool touchBadBlock = false;


    private void Start()
    {
        addingBlockScript = AddingBlock.instance;
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("GoodBlock") && !blockIsChild && !touchBadBlock)
        {

            addingBlockScript.AddBlock(parentGameObject);
            blockIsChild = true;
        }
        if (other.gameObject.CompareTag("BadBlock") && blockIsChild && !touchBadBlock)
        {
            addingBlockScript.RemoveBlock(parentGameObject);
            touchBadBlock = true;
        }


    }
   
}
