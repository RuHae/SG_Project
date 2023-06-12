using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int highscore = 0;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }else if(Instance != this){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
