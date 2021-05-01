using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBlockCheck : MonoBehaviour
{
    [SerializeField] AddingBlock addingBlockScript;

    [SerializeField] BoxCollider triggerCollider;
    [SerializeField] bool wasTouched = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GoodBlock") && !wasTouched)
        {

            Debug.Log($"other game object: {other.collider.gameObject.name}");
            //addingBlockScript.RemoveBlock(gameObj);
            triggerCollider.isTrigger = false;
            wasTouched = true;
        }
    }
}
