using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    private float height;
    private float width;
    private Vector3 ObjSize;

    // Start is called before the first frame update
    void Start(){
        height = Camera.main.orthographicSize * 2f;
        width = height * Screen.width / Screen.height;
        ObjSize = GetComponent<Renderer>().bounds.size;
        if (gameObject.name == "bgCity"){
            transform.localScale = new Vector3(width, height, 1.0f);
            transform.position = new Vector3(0.0f, 0.0f, 10.0f);
        } else {
            transform.localScale = new Vector3(width, height+1.5f, 1.0f);
            transform.position = new Vector3(0.0f, 0.75f, 10.0f);
        }
    }
}
