using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCountBlock : MonoBehaviour
{
    [SerializeField] private int scoreMultiplier;

    ScoreCounter scoreCounter;

    private void Start()
    {
        scoreCounter = ScoreCounter.instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("AvatarCollider"))
        {
            Debug.Log("GameOver");
            scoreCounter.GameOverMultiplicator(scoreMultiplier);
        }
    }
}
