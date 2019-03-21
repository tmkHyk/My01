using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Button[] buutton;
        
	// Use this for initialization
	void Start () {

        if (SceneManager.GetActiveScene().name == "Title")
        {
            buutton = FindObjectsOfType<Button>();
            buutton[0].Select();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                Time.timeScale = 0;
                break;
            case "Main":
                Time.timeScale = 1;
                if (Goal.isClear)
                {
                    SceneManager.LoadScene("Result");
                }
                break;
            case "Result":
                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Title");
                }
                break;
        }

        DontDestroyOnLoad(this.gameObject);
	}

    public void TimeAttack()
    {
        SceneManager.LoadScene("Main");
    }

    public void Endless()
    {
        SceneManager.LoadScene("Endless");
    }
}
