using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text textUI;

    public void Start(){
        textUI.text = "Highscore:" + GameManager.Instance.highscore;
    }
    
    public void move_to_scene(string scene_name) 
    {
        SceneManager.LoadScene(scene_name);
    }   
}
