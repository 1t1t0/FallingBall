using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 
public class GameManage2 : MonoBehaviour
{
    //　スタート用テキストプレハブ
    [SerializeField]
    //private GameObject textPrefab;
    //[SerializeField]
    private TimeManager2 timeManager;
 
    private bool finished;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }
 
    public void Goal() {
        finished = true;
        //　最高タイムの更新
        timeManager.UpdateFastestTime();
    }

    public void Miss() {
        finished = true;
    }
    
    //　ゲームを終了したかどうか
    public bool IsFinished() {
        return finished;
    }
}