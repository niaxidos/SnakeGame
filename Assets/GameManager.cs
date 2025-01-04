using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Snake snake;
    public GameObject menu;
    public GameObject game;

    
    void Update(){
    if(menu.activeSelf){
        game.SetActive(false);
    }
    else{
        game.SetActive(true);
     }
    }

    public void RestartGame(){
        snake.ResetState();
    }

    public void menuSelect(){
        menu.SetActive(true);
    }

    public void easy(){
        menu.SetActive(false);
        Time.fixedDeltaTime = 0.1f;
        snake.ResetState();
    }
    public void normal(){
        menu.SetActive(false);
        Time.fixedDeltaTime = 0.06f;
        snake.ResetState();
    }
    public void expert(){
        menu.SetActive(false);
        Time.fixedDeltaTime = 0.03f;
        snake.ResetState();
    }
}
