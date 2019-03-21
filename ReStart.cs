using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //スペースキーを押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Mainシーンへ
            SceneManager.LoadScene("Main");
        }
	}
}
