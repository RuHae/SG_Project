using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Drill_Move : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private KeyCode Right;
    [SerializeField] private TMP_Text textUI;
    [SerializeField] private TMP_Text Meilenstein;
    [SerializeField] private Image Zark;
    [SerializeField] private AudioClip[] audio;
    private int counter = 0;
    private float moveDirection = -1;
    private float currentMoveDirection;
    private Rigidbody2D RB;
    private SpriteRenderer Drill;
    private AudioSource audioS;
    public float MoveSpeed;
    public float default_angle;
    public float rotation_speed;
    public float centerOffsetCamera = 4;
    private float start;
    private int current;
    private int score;
    private double fortschritt;
    private int verblieben;
    private bool canPlayNext = true;
    public int erdkern; //Erdmittelpunkt ist 6k km


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Drill = GetComponentInChildren<SpriteRenderer>();
        audioS = GetComponent<AudioSource>();
        start = transform.position.y;
        textUI.text = "Score:" + score;
        Meilenstein.text = "";
        erdkern = 600;
    }

    // Update is called once per frame
    void Update()
    {
        Calculation();
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
            Destroy(collision.gameObject); // destroy obstacle we didn't hit
            if(counter == 3){
                if(score > GameManager.Instance.highscore){
                    GameManager.Instance.highscore = score; // set score as Highscore if it is higher then the old one
                }
                SceneManager.LoadScene("Menu");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
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
        fortschritt =  System.Math.Round(((start - transform.position.y)/erdkern)*100, 1);
        verblieben = erdkern - score;
        //textUI.text = "Score:" + score + "\n" + "Fortschritt:" + fortschritt +"%" +"\n" + "Verblieben:" + verblieben;
        textUI.text = "Score:" + score + "\t" + "Fortschritt:" + fortschritt +"%" +"\t" + "Verblieben:" + verblieben;
        
        if(canPlayNext == true){
        if (score == 125){
            Zark.gameObject.SetActive(true);
            Time.timeScale = 0;
            audioS.clip = audio[0];
            audioS.Play();
            Meilenstein.text = "Sie haben leichte Erdbeben ausgelöst.";
            StartCoroutine(DelayedClearMeilensteinText());
        }else if (score == 250){
            Zark.gameObject.SetActive(true);
            Time.timeScale = 0;
            audioS.clip = audio[1];
            audioS.Play();
            Meilenstein.text = "Australien und Europa sind unter Wasser. Die Menschheit gerät in Panik";
            StartCoroutine(DelayedClearMeilensteinText());
        }else if (score == 450){
            Zark.gameObject.SetActive(true);
            audioS.clip = audio[2];
            audioS.Play();            
            Meilenstein.text = "Die USA ist ebenfalls Unterwasser." + "\n" + "Ein Großteil der Menschheit wurde evakuiert.";
            Time.timeScale = 0;
            StartCoroutine(DelayedClearMeilensteinText());
        }else if((erdkern - score) == 0){
            audioS.PlayOneShot(audio[3]);
            Meilenstein.text = "Sie haben den Erdkern erreicht und die Erde zerstört";
            SceneManager.LoadScene("Menu");
            GameManager.Instance.highscore = score;
        }
        }
    }
    IEnumerator DelayedClearMeilensteinText(){
        canPlayNext = false;
        float currentTime = 0;
        float maxTime = audioS.clip.length;
        score += 1;
        while(currentTime<maxTime){ // alernative yield return new WaitForSecondsRealtime(5);
            currentTime += Time.unscaledDeltaTime;
            yield return null;
        }
        Meilenstein.text = "";
        Zark.gameObject.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(1);
        canPlayNext = true;
    }
}
