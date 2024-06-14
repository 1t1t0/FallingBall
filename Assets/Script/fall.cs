using System.Collections;
//使わなかったので一応コメントアウトしている。
//using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

//通常状態のプレイヤーのレイヤー。
	LayerMask defaultPlayerLayer;
//落下状態のプレイヤーのレイヤー。
	LayerMask fallenPlayerLayer;


//落下状態のフラグ。
	public bool isFalling;

//落下してから落下状態がリセットされるまでの距離。
	float endFallDistance = -2.0f;

//落下コルーチン管理用変数。
	Coroutine fall;

//落下開始位置。
	float startFallPositionY;


	void Awake()
	{
		defaultPlayerLayer = LayerMask.NameToLayer("Player");
		fallenPlayerLayer = LayerMask.NameToLayer("FallenPlayer");
	}

	void OnTriggerEnter(Collider col)
	{
//落下中でない状態で、Pitの中心に設定したColliderに触れた場合のみ実行。
		if (!isFalling && col.gameObject.CompareTag("Pit")) {
			StartFall();
		}
	}

	
	void StartFall()
	{        
		fall = StartCoroutine("Fall");
	}

	IEnumerator Fall()
	{
		isFalling = true;
		gameObject.layer = fallenPlayerLayer;
		startFallPositionY = transform.position.y;

		while (true) {

			if (transform.position.y - startFallPositionY <= endFallDistance) {

				isFalling = false;
				gameObject.layer = defaultPlayerLayer;

				yield break;
			}

			yield return null;
		}
	}


//落下コルーチンをリセット(オブジェクトプールで使い回す＆死亡等で強制終了させる場合用)。
	void ResetFall()
	{
		if (fall != null) {
			StopCoroutine(fall);
			fall = null;
		}
	}

}