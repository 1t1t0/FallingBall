using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class Goal3 : MonoBehaviour
{
    [SerializeField]
    private GameManage3 gameManager;
    public GameObject chara;
 
    void OnTriggerEnter(Collider col) {
        if (col.name == chara.name) {
            //　ゲームマネジャーにゴールしたことを知らせる
            gameManager.Goal();
        }
    }
}
