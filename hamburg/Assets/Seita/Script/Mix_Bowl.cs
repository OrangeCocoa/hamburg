using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ボウルまぜまぜ
public class Mix_Bowl : MonoBehaviour
{
    // ==========================================================================
    //                               メンバ変数
    // ==========================================================================
    // 外部入力値
    [SerializeField]
    private int             m_nAddScore;

    // 変数
    private BGM_Manager     m_pBGM_ManagerComponent;
    private int             m_nScore;
    private bool            m_bUpdate;
    private bool            m_bGameEnd;
    private bool            m_bGameStart;


    // ==========================================================================
    //                               メンバ関数
    // ==========================================================================
    // 更新スイッチ
    public void SetUpdateSwitch(bool bUpdate)
    {
        m_bUpdate = bUpdate;
    }

    // スコア渡し
    public int  GetMixScore()
    {
        return m_nScore;
    }

    // ゲーム終了渡し
    public bool GetGameEnd()
    {
        return m_bGameEnd;
    }

    // ゲーム処理
    private void Mix_Bowl_Game()
    {
        // もしBGMが終わっていなければ...
        if(!m_pBGM_ManagerComponent.GetEndBgm())
        {
            // ゲームが開始されているのなら
            if(m_bGameStart)
            {
                // BGMが終わらぬ限り
                if(Input.GetMouseButtonDown(0) && !m_pBGM_ManagerComponent.GetEndBgm())
                {
                    m_nScore += m_nAddScore;
                }
                
                // BGMが終わったら
                if(m_pBGM_ManagerComponent.GetEndBgm())
                {
                    m_bGameEnd = true;
                }
            }

            // もし始めの一回目でクリックがなされたなら
            if(Input.GetMouseButtonDown(0) && !m_bGameStart)
            {
                m_bGameStart = true;
                m_pBGM_ManagerComponent.BGM_Switch(true);
            }
        }
        else
        {
            // 終わりスイッチ
            m_bGameEnd = true;
        }
    }


    // ==========================================================================
    //                                基本関数
    // ==========================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        m_pBGM_ManagerComponent = GetComponent<BGM_Manager>();

        // 初期化
        m_bUpdate = false;
        m_bGameStart = false;
        m_bGameEnd = false;
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // 更新
        if(m_bUpdate)
        {
            // ゲーム処理
            Mix_Bowl_Game();
        }
    }
}
