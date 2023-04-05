using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathUI : MonoBehaviour
{
    static public DeathUI instance;

    [SerializeField] GameObject uiDeath;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        instance = this;
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
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
