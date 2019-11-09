using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrypanScene : MonoBehaviour
{
   

    [SerializeField] private float[] judgeTime;

    /// <summary>
    /// 各判定ごとの加算されるスコア
    /// </summary>
    [SerializeField] private int[] scoreParam;

    /// <summary>
    /// 次のフライ返しまでの時間
    /// </summary>
    [SerializeField] private float interval;

    /// <summary>
    /// フライ返しの回数
    /// </summary>
    [SerializeField] private int loop;

    /// <summary>
    /// circle
    /// </summary>
    [SerializeField] private GameObject circle;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private ParticleSystem particle;

    [SerializeField] private GameObject burg;

    private FRY_STATE fryState;

    private float time;

    private float allJudgeTime;

    private int totalScore;

    private int score;

    private float scoreRate;

    private int loopNum;

    private float maxScale = 1.1f;

    private float minScale = 0.5f;

    enum FRY_STATE
    {
        WAIT,
        FRY
    }

    enum JUDGE
    {
        FAST,
        PERFECT,
        LATE,
    }

    // Start is called before the first frame update
    void Start()
    {
        fryState = FRY_STATE.WAIT;
        ChangeScale(minScale);
        particle.Stop();
        score = 0;
        scoreRate = 0;
        allJudgeTime = judgeTime[0] + judgeTime[1] + judgeTime[2];
        for (int i = 0; i < 3; i++)
        {
            //perfect
            totalScore += scoreParam[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        switch (fryState)
        {
            case (FRY_STATE.WAIT):

                if (time > interval)
                {
                    ChangeState(FRY_STATE.FRY);
                }
                break;

            case (FRY_STATE.FRY):
                
                Debug.Log(time);

                ChangeScale( maxScale - ( ( maxScale - minScale)  * time / allJudgeTime));
                if(time > allJudgeTime)
                {
                    ChangeState(FRY_STATE.WAIT);
                }
                InputKey();
                break;

        }

    }

    /// <summary>
    /// Input
    /// </summary>
    void InputKey()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Judge();
            particle.Emit(1);
        }
    }

    /// <summary>
    /// Judge
    /// </summary>
    void Judge()
    {
        //fast
        if (time < judgeTime[0])
        {
            //演出

            //initialize
            time = 0;
            loopNum++;
            ChangeState(FRY_STATE.WAIT);
            score += scoreParam[0];
            return;
        }

        //perfect
        if (time < judgeTime[1])
        {
            //演出

            //initialize
            time = 0;
            loopNum++;
            ChangeState(FRY_STATE.WAIT);
            score += scoreParam[1];
            return;
        }

        //演出

        //initialize
        time = 0;
        loopNum++;
        ChangeState(FRY_STATE.WAIT);
        score += scoreParam[2];
        
    }

    /// <summary>
    ///ChangeState
    /// </summary>
    /// <param name="s"></param>
    void ChangeState(FRY_STATE s)
    {
        Debug.Log(s);
        if(s == FRY_STATE.FRY)
        {
            ChangeScale(maxScale);
        }

        if(s == FRY_STATE.WAIT)
        {
            ChangeScale(minScale);
            //ここで次に行くことにする
            EndScene();
        }

        fryState = s;
        time = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    void ChangeScale(float f)
    {
        circle.transform.localScale = new Vector3(f, f, f);
    }

    /// <summary>
    /// EndScene
    /// </summary>
    void EndScene()
    {
        //総合評価を判定
        scoreRate = (float)score / totalScore;
        //次のシーンに移行

    }
}
