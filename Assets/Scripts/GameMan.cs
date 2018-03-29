using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMan: MonoBehaviour {

    public Canvas PauseMenu;
    public Button QuitButton;
    public AudioClip click;

	// Use this for initialization
	void Start () {
        //PauseMenu.SetActive(false);
        PauseMenu = PauseMenu.GetComponent<Canvas>();
        PauseMenu.enabled = !PauseMenu.enabled;
        //QuitButton = QuitButton.GetComponent<Button>();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseIt();
        }

    }
    void quitToMain(){
        Debug.Break();
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }
    public void PauseIt(){
        PauseMenu.enabled = !PauseMenu.enabled;

        if(PauseMenu.enabled){
            Time.timeScale = 0;
        }
        if(!PauseMenu.enabled){
            Time.timeScale = 1;
        }
    }
    public void ClickBtn()
    {
        GetComponent<AudioSource>().clip = click;
        GetComponent<AudioSource>().Play();

    }

}
