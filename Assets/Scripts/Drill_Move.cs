using System.Collections;
using System.Collections.Generic;
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
    private int start;
    private int current;
    private int score;
    public int Highscore;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Drill = GetComponentInChildren<SpriteRenderer>();
        start = (int)(transform.position.y+ 0.5f);
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

        // calculate score and set the TextUI
        current = (int)(transform.position.y + 0.5f);
        score = start - current;
        textUI.text = "Score:" + score;

        camera.transform.position = new Vector3(0, transform.position.y - centerOffsetCamera, -10); // Camera default following the drill only on y direction
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Obstacle")){
            counter += 1;
            if (counter == 1) Drill.color = Color.magenta; 
            if (counter == 2) Drill.color = Color.red; 
            Debug.Log("hit Obstacle");
            Destroy(collision.gameObject);
            if(counter == 3){
                SceneManager.LoadScene("Menu");
                Highscore = score;
            // set Highscore if it is higher then the old one
            }
        }
    }
}
