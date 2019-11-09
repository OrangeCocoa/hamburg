using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ゲームマネージャ
public class Game_Manager : MonoBehaviour
{
    // ==========================================================================
    //                               メンバ変数
    // ==========================================================================
    // 定数
    public enum GAME_MODE
    {
        SOZAI_ERABI,        // 素材選び
        KAKI_MAZE,          // 掻き混ぜ
        MODE_MAX            // モード最大数
    };
       
    // 外部入力値
    [SerializeField]
    private GameObject      m_pSelectItemObject;
    private Select_Point    m_pSelectPointComponent;
    [SerializeField]
    private GameObject      m_pMixBowlObject;
    private Mix_Bowl        m_pMixBowlComponent;

    // 変数
    private GAME_MODE   m_mGameMode;        // ゲームモード
    private int         m_nGameScore;       // ゲームスコア


    // ==========================================================================
    //                               メンバ関数
    // ==========================================================================
    // モード渡し
    public  GAME_MODE   GetGAME_MODE()
    {
        return m_mGameMode;
    }


    // ==========================================================================
    //                                基本関数
    // ==========================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        m_pSelectPointComponent = m_pSelectItemObject.GetComponent<Select_Point>();
        m_pMixBowlComponent     = m_pMixBowlObject.GetComponent<Mix_Bowl>();

        // 初期化
        m_mGameMode = GAME_MODE.SOZAI_ERABI;
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // モードでアップデート切り替え
        switch(m_mGameMode)
        {
            // 素材選び処理
            case GAME_MODE.SOZAI_ERABI:
                {
                    // 更新許可
                    m_pSelectPointComponent.SetUpdateSwitch(true);

                    // 選択が終了しているなら...
                    if (m_pSelectPointComponent.GetSelectEndFlag())
                    {
                        // ゲームモードと更新許可を切り替える
                        m_mGameMode = GAME_MODE.KAKI_MAZE;
                        m_pMixBowlComponent.SetUpdateSwitch(false);
                    }

                    break;
                }

            // 素材掻き混ぜ処理
            case GAME_MODE.KAKI_MAZE:
                {
                    // 更新許可
                    m_pMixBowlComponent.SetUpdateSwitch(true);

                    // ゲームが終了したら...
                    if(m_pMixBowlComponent.GetGameEnd())
                    {
                        // 最終スコア
                        m_nGameScore = m_pMixBowlComponent.GetMixScore() + m_pSelectPointComponent.GetSelectScore();
                        Debug.Log(m_nGameScore);
                    }

                    break;
                }
        }
    }
}
