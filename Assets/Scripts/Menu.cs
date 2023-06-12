using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void move_to_scene(string scene_name) 
    {
        SceneManager.LoadScene(scene_name);
    }   
}
