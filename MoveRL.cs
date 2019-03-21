using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRL : MonoBehaviour {

    [SerializeField, Range(0, 10), Tooltip("移動距離")]
    float distance = 1;
    [SerializeField, Range(-1, 0), Tooltip("移動速度")]
    float velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //左右往復移動
        var pos = transform.position;
        velocity = (velocity == 0) ? 1 : velocity;
        transform.position = new Vector3(pos.x + Mathf.Sin(Time.time) * distance * velocity * Time.timeScale, pos.y, pos.z);

	}

    void OnCollisionEnter(Collision other)
    {
        if (this.gameObject.tag != "Enemy" && other.gameObject.tag == "Player")
        {
            transform.SetParent(other.gameObject.transform);
        }
    }
}
