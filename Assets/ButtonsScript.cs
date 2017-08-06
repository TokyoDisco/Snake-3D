using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour {
    //funkcje dla przyciskow i tekstow

    public void Update()
    {
        if (name == "ScoreText")
        {
            GetComponentInChildren<Text>().text = "Your Score " + GameObject.Find("SnakeHead").GetComponent<PlayerControler>().score;
        }

        if (name == "PlayerScoreText")
        {
            GetComponent<Text>().text = "Score: " + GameObject.Find("SnakeHead").GetComponent<PlayerControler>().score  + "Tail fragments:" + GameObject.Find("SnakeHead").GetComponent<PlayerControler>().tailobjectList.Count;
        }
    }

    

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("MainGameplayScene");
    }



    public void MuteBtn()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 0.5f;
        }
    }


    public void AddVolume()
    {
        AudioListener.volume += 0.1f;
        if (AudioListener.volume == 1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            
        }
        
    }

    public void ReduceVolume()
    {
        AudioListener.volume -= 0.1f;
        if (AudioListener.volume == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        
    }


}
