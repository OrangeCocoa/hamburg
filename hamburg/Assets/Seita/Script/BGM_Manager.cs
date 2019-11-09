using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BGM_マネージャー
public class BGM_Manager : MonoBehaviour
{
    // ==========================================================================
    //                               メンバ変数
    // ==========================================================================
    // 変数
    [SerializeField]
    private AudioClip   m_pBGM;                 // かき混ぜBGM
    private bool        m_bPlay_Bgm;            // BGM再生
    private bool        m_bBgm_Start;           // BGM再生中フラグ
    private bool        m_bEnd_Bgm;             // BGM終了フラグ
    private AudioSource m_pBGM_Source;          // オーディオソースコンポーネント
    private Animator    m_pAnimetion;           // かき混ぜアニメ


    // ==========================================================================
    //                               メンバ関数
    // ==========================================================================
    // BGM再生スイッチ切り替え
    public  void    BGM_Switch(bool bPlay)
    {
        m_bPlay_Bgm = bPlay;
    }

    // BGM終了渡し
    public  bool    GetEndBgm()
    {
        return m_bEnd_Bgm;
    }

    // BGMの終了取得(内には関数が入る)
    public delegate void CallbackfunctionType();
    private IEnumerator CheckingBGMEnd(CallbackfunctionType CallBack)
    {
        while(true)
        {
            yield return new WaitForFixedUpdate();

            // 終了したら...
            if(!m_pBGM_Source.isPlaying)
            {
                // 関数を呼ぶ
                CallBack();
                break;
            }
        }
    }


    // ==========================================================================
    //                                基本関数
    // ==========================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        m_bPlay_Bgm     = false;
        m_bEnd_Bgm      = false;
        m_bBgm_Start    = false;
        m_pBGM_Source   = GetComponent<AudioSource>();
        m_pAnimetion    = GetComponent<Animator>();
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // BGM流し処理
        if (m_bPlay_Bgm)
        {
            m_bPlay_Bgm = false;
            m_bBgm_Start = true;
            m_pAnimetion.SetBool("Mix", true);
            m_pBGM_Source.PlayOneShot(m_pBGM);
        }

        // BGM終了確認
        StartCoroutine(CheckingBGMEnd(() =>
        {
            // BGMが開始しているならば...
            if (m_bBgm_Start)
            {
                // BGM終了時の処理
                m_pAnimetion.SetBool("Mix", false);
                m_bEnd_Bgm = true;
            }
        }));
    }
}
