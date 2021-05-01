using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] GameObject[] goodBlocksObj;
    private List<Vector3> goodBListPos;
    private List<Quaternion> goodBListRot;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerStartObj;
    [SerializeField] GameObject cameraPrefab;
    [SerializeField] Transform cameraPosition;
    private Vector3 cameraStartPos;
    private Transform playerStartTransf;
    private GameObject playerObj;
    private GameObject cameraObj;

    [SerializeField] GameObject[] coinsGameObjects;

    private void Awake()
    {
        if (LevelManager.instance == null)
            instance = this;
        else
        {
            Debug.LogError("LevelManager already exist");
            Destroy(this.gameObject);
        }    
    }

    void Start()
    {
       
        playerObj = playerStartObj.gameObject;
        cameraObj = cameraPosition.gameObject;

        cameraStartPos = cameraPosition.position;
        playerStartTransf = playerStartObj.transform;

        

        goodBListPos = new List<Vector3>();
        goodBListRot = new List<Quaternion>();
        for (int i = 0; i < goodBlocksObj.Length; i++)
        {
            goodBListPos.Add(goodBlocksObj[i].transform.localPosition);
            goodBListRot.Add(goodBlocksObj[i].transform.localRotation);
        }
    }


    public void ResetObjectPositions()
    {
        DeletePlayer();
        CreatePlayer();
        cameraPosition.position = cameraStartPos;

        for (int i = 0; i < goodBlocksObj.Length; i++)
        {
            goodBlocksObj[i].transform.position = goodBListPos[i];
            goodBlocksObj[i].transform.rotation = goodBListRot[i];
        }

        foreach (var item in coinsGameObjects)
        {
            item.SetActive(true);
        }
    }

    private void CreatePlayer()
    {
        playerObj = Instantiate(playerPrefab, playerStartTransf.position, playerStartTransf.rotation);
    }

    private void DeletePlayer()
    {
        Destroy(playerObj);
    }

    
}
