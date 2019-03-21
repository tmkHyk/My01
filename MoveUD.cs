using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUD : MonoBehaviour {

    [SerializeField,Range(0,10),Tooltip("移動距離")]
    float distance = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //上下往復移動
        var pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + Mathf.Sin(Time.time) * distance*Time.timeScale, pos.z);

    }
}
