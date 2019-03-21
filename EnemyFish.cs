using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //回転
        transform.Rotate(transform.rotation.x + Time.deltaTime*112, 0, 0);
        //回転移動
        transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time*2) / 5, transform.position.y + Mathf.Sin(-90+Time.time*2) / 5, transform.position.z);

	}
}
