using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private GameObject parentobj;
    [SerializeField] private int coinValue = 1;
    private ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = ScoreCounter.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        parentobj.SetActive(false);
        scoreCounter.AddScore(coinValue);
    }

}
