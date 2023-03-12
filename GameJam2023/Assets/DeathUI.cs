using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathUI : MonoBehaviour
{
    static public DeathUI instance;

    [SerializeField] GameObject uiDeath;
    private void Awake()
    {
        instance = this;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowUI()
    {
        uiDeath.SetActive(true);
    }
}
