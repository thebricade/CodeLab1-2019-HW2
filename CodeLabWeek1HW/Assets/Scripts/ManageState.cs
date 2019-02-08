using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    title,
    pause,
    playing
}

public class ManageState : MonoBehaviour
{
    private GameState currentState;
    private GameObject pauseMenu;
    private GameObject[] titleScreenObjects;
    
    //Title Screen 
    public Button playButton;
    
    // Start is called before the first frame update
    void Start()
    { 
        currentState = GameState.title;
        GameObject titleMenu = Instantiate(Resources.Load<GameObject>("Prefabs/TitleMenu"));
        playButton = GameObject.Find("Play").GetComponent<Button>();
        playButton.onClick.AddListener(TaskOnClick);

       
    }

    // Update is called once per frame
    void Update()
    {
        checkGameState();
        Debug.Log("current game state is " + currentState);
       
    }

    public void checkGameState()
    {
        switch (currentState)
        {
            case GameState.pause:
                //When the Gamestate is PAUSED set the timeScale to 0 to stop everything from spawning and moving
                if (Time.timeScale > 0f)
                {
                    GameObject pauseMenu = Instantiate(Resources.Load<GameObject>("Prefabs/PauseMenu"));
                    Time.timeScale = 0f;  
                }
                
                //when you press SPACE in a PAUSED state you should go back to PLAYING
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(GameObject.FindWithTag("Pause"));
                    currentState = GameState.playing;
                }
                break;
            case GameState.playing:
                Time.timeScale = 1.0f;
                
                //While in PLAYING state if the SPACE is pressed 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentState = GameState.pause;
                }
                //Time.fixedDeltaTime = 1.0f;
                break;
            case GameState.title:
                Time.timeScale = 0f;
                
                break;
        }
    }

    void TaskOnClick()
    {
        currentState = GameState.playing;
    
        //get all objects in the TITLE State and put them in an array to destroy
        titleScreenObjects = GameObject.FindGameObjectsWithTag("TitleScreen");

        for (var i = 0; i < titleScreenObjects.Length; i++)
        {
            Destroy(titleScreenObjects[i]);
        }
    }

}
