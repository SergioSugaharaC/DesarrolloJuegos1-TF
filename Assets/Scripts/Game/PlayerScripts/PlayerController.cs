using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{
    public int carril = 0;
    private Animator playerAnim;
    public KeyCode cambiarCarril;
    public KeyCode saltar;
    public GameObject carril0;
    public GameObject carril1;
    public Text CantVidastxt;
    private bool canJump = false;
    public float jumpForce;
    private Rigidbody2D body;
    private int hp = 3;
    void Awake(){
        playerAnim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.HasKey("PlayerHP")){
            hp = PlayerPrefs.GetInt("PlayerHP");
        }
    }

    void makeJump(){
        if (canJump){
            canJump = false;
            body.velocity = new Vector2(0, jumpForce);
            playerAnim.Play("Player_Jump");
        }
    }

    void Update(){
        if(Input.GetKeyDown(cambiarCarril)){
            if(carril == 0){
                carril = 1;
                Vector3 temp = transform.position;
                temp.y += carril;
                temp.z = 10;
                transform.position = temp;
                carril1.SetActive(true);
            } else{
                Vector3 temp = transform.position;
                temp.y -= carril;
                temp.z = 5;
                transform.position = temp;
                carril = 0;
                carril1.SetActive(false);
            }
        }

        if(Mathf.Abs(body.velocity.y) == 0 && Input.GetKeyDown(saltar)){
            canJump = true;
        }
        makeJump();
        if(hp <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Terreno"){
            playerAnim.Play("Player_Walk");
        }   
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enfermo"){
            int otherY = (int)(other.bounds.center.y);
            if (4 - carril == -otherY){
                hp--;
                CantVidastxt.text = "x" + hp.ToString();
                other.gameObject.SetActive(false);
            }
        }
        if(other.gameObject.tag == "Obstaculo"){
            hp = 0;
        }
    }
}
