using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessManager : MonoBehaviour {

    public List<GameObject> floors = new List<GameObject>();
    bool isendless;

	// Use this for initialization
	void Start () {




        if (SceneManager.GetActiveScene().name == "Endless")
        {
            isendless = true;
        }
        else
        {
        }

        var gameObjs = GameObject.FindGameObjectsWithTag("Floor");
        for (int i = 0; i < gameObjs.Length; i++)
        {
            floors.Add(gameObjs[i].gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
