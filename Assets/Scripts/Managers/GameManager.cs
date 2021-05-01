using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject StartUI;

    [SerializeField] private GameObject GameActiveUI;

    [SerializeField] private GameObject PauseUI;

    [SerializeField] private GameObject GameOverUI;


    private LevelManager levelManager;

    private void Start()
    {
        levelManager = LevelManager.instance;
    }

    public void StartGame()
    {
        StartUI.SetActive(true);
        GameActiveUI.SetActive(false);
    }

    public void PauseGame()
    {
        GameActiveUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        PauseUI.SetActive(false);
        GameActiveUI.SetActive(true);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        GameActiveUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        GameActiveUI.SetActive(false);
        PauseUI.SetActive(false);
        StartUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
