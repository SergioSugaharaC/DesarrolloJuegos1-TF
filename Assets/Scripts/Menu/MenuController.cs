using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button btnPlay;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay.onClick.AddListener(() => goGame());
    }

    void goGame()
    {
        SceneManager.LoadScene("Game");
    }



    // Update is called once per frame
    void Update()
    {

    }
}
