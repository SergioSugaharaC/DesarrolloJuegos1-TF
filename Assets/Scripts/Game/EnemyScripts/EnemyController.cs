//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [Header("Enemy Variables")]
    [SerializeField] private List<GameObject> elements = new List<GameObject>();
    [SerializeField] private float startX;
    private List<GameObject> pool = new List<GameObject>();

    [SerializeField] private float Rate = 1.0f;
    private float timeElapsed = 0f;
   

    // Start is called before the first frame update
    void Start(){
        GenerateObjectPool();
    }

    void GenerateObjectPool(){
        for (int i = 0; i < elements.Count; i++){
            for (int j = 0; j < elements.Count; j++){
                int rand = (int)Random.Range(0,100) % 2;
                float posY = -(4f + rand*100);
                GameObject Obstacle = Instantiate(elements[i], new Vector3(startX, posY, 1.0f), Quaternion.identity);
                Obstacle.SetActive(false);
                pool.Add(Obstacle);
            }
        }
    }

    // Update is called once per frame
    void Update(){
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= Rate){
            timeElapsed = 0f;
            GetFirstDead();
        }
    }

    void GetFirstDead(){
        while (true){
            int index = Random.Range(0, pool.Count - 1);
            if (!pool[index].activeInHierarchy){
                int rand = (int)Random.Range(0,100) % 2;
                float posY = rand == 0 ? -5f : -4f;//-(4f + rand);
                float posZ = rand == 0 ? 5f :  10f;
                pool[index].SetActive(true);
                pool[index].transform.position =
                   new Vector3(8.5f, posY, posZ);
                break;
            }
        }
    }
}
