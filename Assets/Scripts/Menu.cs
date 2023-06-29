using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text textUI;
    [SerializeField] private Image newImage; 
    [SerializeField] private Sprite spriteOn;
    [SerializeField] private Sprite spriteOff;
    [SerializeField] private AudioMixer audioMixer;

    public void Start(){
        textUI.text = "Highscore:" + GameManager.Instance.highscore;
        float vol = 0;
        audioMixer.GetFloat("masterVolume", out vol);
        if(vol <= -30){
            ChangeButtonImage(false);
        }
    }
    
    public void move_to_scene(string scene_name) 
    {
        SceneManager.LoadScene(scene_name);
    } 

    public void ChangeButtonImage(bool onOff) 
    {
        if(onOff == true){
            newImage.sprite = spriteOn;
            audioMixer.SetFloat("masterVolume", -20);
        }else{
            newImage.sprite = spriteOff;
            audioMixer.SetFloat("masterVolume", -80);
        }
    } 
}
