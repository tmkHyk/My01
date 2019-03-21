using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    Rigidbody rb;
    Vector3 startPos;

    //ジャンプ中か　trueのときジャンプ中
    public bool isJump = false;

    //移動変位を格納
    float moveX, moveZ;
    [SerializeField,Range(0,100),Tooltip("歩行スピード")]
    float speed;
    [SerializeField, Range(0, 10), Tooltip("ジャンプ力")]
    float jumpPower;

    public static Vector3 nowPos;
    public GameObject otherObj;
    GameObject floor;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        floor = GameObject.Find("Floor");
        startPos = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Move();
        //ジャンプ処理
        Jump();

        //y座標値が0以下になったら
        if (transform.position.y <= 0)
        {
            //Resultシーンへ
            //SceneManager.LoadScene("Result");

            var otherPos = otherObj.transform.position;
            this.transform.position = new Vector3(otherPos.x, otherPos.y + 2, otherPos.z);
            //otherObj.transform.position = new Vector3(nowPos.x, nowPos.y, otherObj.transform.position.z);
        }
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        //X軸方向の移動変位
        moveX = Input.GetAxis("Horizontal") * 0.01f * Speed(speed) * Time.timeScale;
        //Z軸方向の移動変位
        moveZ = Input.GetAxis("Vertical") * 0.01f * Speed(speed) * Time.timeScale;
        //前後左右移動
        transform.Translate(moveX, 0, moveZ);
    }

    /// <summary>
    /// 歩行速度
    /// </summary>
    /// <param name="speed"></param>
    /// <returns></returns>
    float Speed(float speed)
    {
        //ジャンプ中でない、かつシフトを押していたら速度アップ(走る)
        if (!isJump && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            return speed * 2;
        }
        return speed;
    }

    /// <summary>
    /// 歩いているか
    /// trueのとき歩いている
    /// </summary>
    /// <returns></returns>
    bool IsRunning()
    {
        //動いていないとき
        if (moveX != 0 || moveZ != 0)
        {
            return true;
        }
        return false;
    }

    void Jump()
    {
        //スペースキーを押され、かつジャンプ中でないとき
        if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
        {
            //ジャンプ中である
            isJump = true;
            //ジャンプ
            rb.velocity = transform.up * jumpPower;
        }
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            //Floorタグのオブジェクトに衝突したら
            case "Floor":
                //ジャンプしていない
                isJump = false;
                //衝突しているFloorの子オブジェクトにする
                transform.SetParent(other.gameObject.transform);
                break;
            //Enemyタグのオブジェクトに衝突したら
            case "Enemy":
                //Resultシーンへ
                transform.position = startPos;
                break;
        }
    }

    /// <summary>
    /// 衝突範囲から離れた
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionExit(Collision other)
    {
        //離れたオブジェクトがMoveFloorタグなら
        if (other.gameObject.tag == "Floor")
        {
            //子オブジェクトを解除、独立する
            transform.parent = null;

            otherObj = other.gameObject;
            nowPos = other.gameObject.transform.position;
        }
    }
}