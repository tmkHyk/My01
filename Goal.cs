using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public static bool isClear;

	// Use this for initialization
	void Start () {

        isClear = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isClear = true;
        }
    }
}
