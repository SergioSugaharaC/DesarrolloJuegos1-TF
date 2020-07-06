using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button btnMainMenu;
    [SerializeField] Button btnRetry;
    void Start()
    {
        btnMainMenu.onClick.AddListener(() => goMenu());
        btnRetry.onClick.AddListener(() => goGame());
    }

    void goGame() 
    {
        PlayerPrefs.SetInt("PlayerHP",3);
        SceneManager.LoadScene("Game");
    }
    void goMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}