using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Drill_Endless : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private KeyCode Right;
    [SerializeField] private TMP_Text textUI;
    private int counter = 0;
    private float moveDirection = -1;
    private float currentMoveDirection;
    private Rigidbody2D RB;
    private SpriteRenderer Drill;
    public float MoveSpeed;
    public float default_angle;
    public float rotation_speed;
    public float centerOffsetCamera = 4;
    private float start;
    private int current;
    private int score;


    // Start is called before the first frame update
    void Start(){
        RB = GetComponent<Rigidbody2D>();
        Drill = GetComponentInChildren<SpriteRenderer>();
        start = transform.position.y;
        textUI.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(Right)){
            moveDirection = 1;
        }else if(Input.GetKeyUp(Right)){
            moveDirection = -1;
        }
        currentMoveDirection = Mathf.Lerp(currentMoveDirection, moveDirection, rotation_speed*Time.deltaTime); // Linear Interpolation for smoother rotation
        transform.rotation = Quaternion.Euler(0, 0, default_angle*currentMoveDirection); // Rotation angle
        RB.velocity = (transform.up * -1) * MoveSpeed;  // Drill going locally down

        Calculation();

        camera.transform.position = new Vector3(0, transform.position.y - centerOffsetCamera, -10); // Camera default following the drill only on y direction
    }

    void OnCollisionEnter2D(Collision2D collision){
        Color red_light = new Color(1f, 0.5f, 0.5f);
        Color red_dark = new Color(1f, 0f, 0f);
        
        if (collision.gameObject.CompareTag("Obstacle")){
            counter += 1;
            if (counter == 1) Drill.material.color = red_light; //Color(1f, 0f,0f); // change color of drill after collision
            if (counter == 2) Drill.material.color = red_dark; //Color.red; 
            Debug.Log("hit Obstacle");
            Destroy(collision.gameObject); // destroy obstacle we hit
            if(counter == 3){
                if(score > GameManager.Instance.highscore){
                    GameManager.Instance.highscore = score; // set score as Highscore if it is higher then the old one
                }
                SceneManager.LoadScene("Menu");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Erdschicht1")){
            Debug.Log("Erdschicht1");
            default_angle = 20;
            MoveSpeed = 8;
        }
        if(other.gameObject.CompareTag("Erdschicht2")){
            Debug.Log("Erdschicht2");
            default_angle = 40;
            MoveSpeed = 10;
        }
        if(other.gameObject.CompareTag("Erdschicht3")){
            Debug.Log("Erdschicht3");
            default_angle = 50;
            MoveSpeed = 10;
        }
        if(other.gameObject.CompareTag("Erdschicht4")){
            Debug.Log("Erdschicht4");
            default_angle = 10;
            MoveSpeed = 13;
        }
        if(other.gameObject.CompareTag("Erdschicht5")){
            Debug.Log("Erdschicht5");
            default_angle = 20;
            MoveSpeed = 14;
        }
    }
    void Calculation(){
        // calculate score and set the TextUI
        current = (int)(transform.position.y + 0.5f);
        score = (int)(start+0.5f) - current;
        textUI.text = "Score:" + score;
    }
}
