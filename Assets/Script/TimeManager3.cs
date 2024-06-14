using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class TimeManager3 : MonoBehaviour
{
    [SerializeField]
    private GameManage3 gameManager;
    private float currentTime;
    private Text currentTimeText;
    private Text fastestTimeText;
    private static float fastestTime = 999.999f;
 
    // Start is called before the first frame update
    void Start()
    {
        currentTimeText = transform.Find("CurrentTimeText").GetComponent<Text>();
        //　最速タイムを表示
        fastestTimeText = transform.Find("FastestTimeText").GetComponent<Text>();
        fastestTimeText.text = fastestTime.ToString("0.000");
    }
 
    // Update is called once per frame
    void Update()
    {
        //　ゴールしていなければ時間を計測
        if (!gameManager.IsFinished()) {
            currentTime += Time.deltaTime;
            currentTimeText.text = currentTime.ToString("0.000");
        }
    }
 
    //　最高タイムの更新
    public void UpdateFastestTime() {
        if (currentTime < fastestTime) {
            fastestTime = currentTime;
        }
    }
}