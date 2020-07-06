using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D collider2D;
    private List<string> tags = new List<string>() {"Enemy","Zombie"};

    // Start is called before the first frame update
    void Start(){
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other){
        GameObject Enemy = other.gameObject;
        Debug.Log(Enemy.tag);
        if (Enemy.tag == "Obstaculo" || Enemy.tag == "Enfermo"){
            Enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
