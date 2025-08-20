using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    private GameObject loseUI;
    private GameObject winUI;
    public static LevelStateManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); 
    }

    public void OnPlayerLose()
    {
        Debug.Log("Death");
        loseUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnPlayerWin()
    {
        Debug.Log("Win");
        winUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
