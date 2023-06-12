using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Drill_Move : MonoBehaviour
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
    private double fortschritt;
    private int verblieben;
    public int erdkern = 600; //Erdmittelpunkt ist 6k km


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Drill = GetComponentInChildren<SpriteRenderer>();
        start = transform.position.y;
        textUI.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Right))
        {
            moveDirection = 1;
        }else if(Input.GetKeyUp(Right)){
            moveDirection = -1;
        }
        currentMoveDirection = Mathf.Lerp(currentMoveDirection, moveDirection, rotation_speed*Time.deltaTime); // Linear Interpolation for smoother rotation
        transform.rotation = Quaternion.Euler(0, 0, default_angle*currentMoveDirection); // Rotation angle
        RB.velocity = (transform.up * -1) * MoveSpeed;  // Drill going locally down
        // RB.velocity = new Vector2(moveDirection, 0)* MoveSpeed;
        Calculation();
       

        camera.transform.position = new Vector3(0, transform.position.y - centerOffsetCamera, -10); // Camera default following the drill only on y direction
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Obstacle")){
            counter += 1;
            if (counter == 1) Drill.color = Color.magenta; // change color of drill after collision
            if (counter == 2) Drill.color = Color.red; 
            Debug.Log("hit Obstacle");
            Destroy(collision.gameObject); // destroy obstacle we didn't hit
            if(counter == 3){
                if(score > GameManager.Instance.highscore){
                    GameManager.Instance.highscore = score; // set score as Highscore if it is higher then the old one
                }
                SceneManager.LoadScene("Menu");

            }
        }
    }
    void Calculation(){
        // calculate score and set the TextUI
        current = (int)(transform.position.y + 0.5f);
        score = (int)(start+0.5f) - current;
        fortschritt =  System.Math.Round(((start - transform.position.y)/erdkern)*100, 1);
        verblieben = erdkern - score;
        textUI.text = "Score:" + score + "\n" + "Fortschritt:" + fortschritt +"%" +"\n" + "Verblieben:" + verblieben;

        // 
        if((erdkern-score) == 0){
            // ToDo Textbox: Sie haben Gewonnen die Erde ist zerstört
            SceneManager.LoadScene("Menu"); 
            GameManager.Instance.highscore = score;
        }
    }
}
