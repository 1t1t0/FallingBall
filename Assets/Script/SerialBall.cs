using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SerialBall : MonoBehaviour {

	public SerialHandler serialHandler;
	public Text text;
	//public GameObject ball;

    float speed=0.5f;
	private Rigidbody rb;
   // float angularSpeed = 360.0f;
	
	//private Vector3 dir;

	// Use this for initialization
	void Start () {
		//信号を受信したときに、そのメッセージの処理を行う
		serialHandler.OnDataReceived += OnDataReceived;
		rb=GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		//dir=Vector3.zero;
	}

	/*
	 * シリアルを受け取った時の処理
	 */
	void OnDataReceived(string message) {


		try {
			string[] angles = message.Split(',');
			text.text = "x:" + angles[0] + "\n" + "y:" + angles[1] + "\n" + "z:" + angles[2] + "\n"; // シリアルの値をテキストに表示

			// Vectorは前から順番にx,y,zだけど、そのままセットすると
			// Unity上の回転の見た目が変になるので、y,zの値を入れ替えている。
			float moveH = float.Parse(angles[0]);
            float moveV = float.Parse(angles[1]); // ここがポイント！
            Vector3 movement = new Vector3(moveH, 0, moveV);
            rb.AddForce(movement * speed);
    	   
        } catch (System.Exception e) {
			Debug.LogWarning(e.Message);
		}
	}
}
