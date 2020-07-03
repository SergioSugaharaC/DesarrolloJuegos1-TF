using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Text time;
    [SerializeField] MeshRenderer City;
    [SerializeField] Material bg1;
    [SerializeField] Material bg2;
    [SerializeField] Material bg3;
    [SerializeField] Material bg4;
    private float Tiempo = 60.0f;
    public int Level;

    void Start()
    {
        if (PlayerPrefs.HasKey("Level")){
            Level = PlayerPrefs.GetInt("Level");
        }
        switch(Level){
            case 1:
                City.material = bg1;
                break;
            case 2:
                City.material = bg2;
                break;
            case 3:
                City.material = bg3;
                break;
            case 4:
                City.material = bg4;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo -= Time.deltaTime;
        time.text = "Time: " + Tiempo.ToString("f0");
        if(Tiempo <= 0.0f){
            if(Level <= 3){
                Level++;
            } else{
                Level = 1;
            }
            PlayerPrefs.SetInt("Level",Level);
            SceneManager.LoadScene("Game");
        }
    }
}
