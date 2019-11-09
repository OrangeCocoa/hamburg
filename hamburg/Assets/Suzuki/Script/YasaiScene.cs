using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YasaiScene : MonoBehaviour
{
    [SerializeField] float endTime;

    [SerializeField] GameObject yasai;
    [SerializeField] GameObject knife;
    [SerializeField] float height;
    [SerializeField] float speed;
    [SerializeField] Text text;

    private int clickCount;

    private float time;

    private bool isAction;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        clickCount = 0;
        time = 0;
        isAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > endTime)
        {
            EndScene();
        }

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            clickCount++;
            text.text = clickCount.ToString();
        }

        UpdateKnifeMotion();
    }

    /// <summary>
    /// 
    /// </summary>
    void UpdateKnifeMotion()
    {
        Vector3 p = knife.transform.position;
        knife.transform.position = new Vector3(p.x,startPos.y + height * Mathf.Cos(time*speed), p.z);
        
    }

    /// <summary>
    /// /
    /// </summary>
    void EndScene()
    {
        //スコアの計算
        float score = clickCount;

        //次のシーンへ

    }
}
