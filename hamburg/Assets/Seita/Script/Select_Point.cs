using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 選択したオブジェクトでポイント
public class Select_Point : MonoBehaviour
{
    // ==========================================================================
    //                               メンバ変数
    // ==========================================================================
    // 定数
    public enum SELECT_ITEM
    {
        無し,
        骨,
        肉,
        蟲,
        野菜,
        小麦粉,
        バター,
        ワイン,
        MAX
    };

    // 外部入力値
    [SerializeField]
    GameObject      m_pSourceObject;            // ソースオブジェクト
    Source_Color    m_pSourceColorComponent;    // ソースカラーコンポーネント
    [SerializeField]
    private int     m_nMaxSelect;               // 選択物最大数
    [SerializeField]
    private int     m_nDefaultPoint;            // 通常加算ポイント
    [SerializeField]
    private int     m_nBounusPoint;             // ボーナス加算ポイント
    [SerializeField]
    private Color   m_pDefaultColor;            // 初期ソース色

    // 変数
    private SELECT_ITEM     m_mOldSelectItem;       // 前選択オブジェクト
    private bool            m_bUpdate;              // 更新許可
    private bool            m_bEndSelect;           // 選択が終了している
    private int             m_nSourcePoint;         // ソースポイント
    private int             m_nSelectCount;         // 選択した数
    private float           m_fAddAlfa;             // 加算α値
    private Color           m_pColor;               // 色


    // ==========================================================================
    //                               メンバ関数
    // ==========================================================================
    // ポイント加算
    public  void AddSourcePoints(string sSelectIten)
    {
        // 選択最大数に達していなければ
        if (m_nSelectCount < m_nMaxSelect)
        {
            // 選択したアイテムの数を+1
            m_nSelectCount++;

            // 色のα追加
            m_pColor.a += m_fAddAlfa;

            // 接触している物で処理を分岐
            switch (sSelectIten)
            {
                // 骨
                case "骨":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r += 0.1f;
                        m_pColor.g += 0.1f;
                        m_pColor.b += 0.1f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.骨;

                        break;
                    }

                // 野菜
                case "野菜":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r += 0.0f;
                        m_pColor.g += 0.1f;
                        m_pColor.b += 0.0f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.野菜;

                        break;
                    }


                // ワイン
                case "ワイン":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r += 0.1f;
                        m_pColor.g += 0.0f;
                        m_pColor.b += 0.0f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.ワイン;

                        break;
                    }

                // バター
                case "バター":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r += 0.1f;
                        m_pColor.g += 0.1f;
                        m_pColor.b += 0.0f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.バター;

                        break;
                    }

                // 小麦粉
                case "小麦粉":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r += 0.05f;
                        m_pColor.g += 0.05f;
                        m_pColor.b += 0.05f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.小麦粉;

                        break;
                    }

                // 蟲
                case "蟲":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r -= 0.1f;
                        m_pColor.g += 0.2f;
                        m_pColor.b -= 0.1f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.蟲;

                        break;
                    }

                // 肉
                case "肉":
                    {
                        // ポイント加算
                        m_nSourcePoint += m_nDefaultPoint;

                        // 色追加
                        m_pColor.r += 0.1f;
                        m_pColor.g -= 0.08f;
                        m_pColor.b -= 0.08f;

                        // 過去データと比較して追加ポイントを発生させる
                        switch (m_mOldSelectItem)
                        {
                            // 何もなし
                            case SELECT_ITEM.無し:
                                {
                                    break;
                                }

                            // 骨
                            case SELECT_ITEM.骨:
                                {
                                    break;
                                }

                            // 肉
                            case SELECT_ITEM.肉:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 蟲
                            case SELECT_ITEM.蟲:
                                {
                                    break;
                                }

                            // 野菜
                            case SELECT_ITEM.野菜:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 小麦粉
                            case SELECT_ITEM.小麦粉:
                                {
                                    break;
                                }

                            // バター
                            case SELECT_ITEM.バター:
                                {
                                    break;
                                }

                            // ワイン
                            case SELECT_ITEM.ワイン:
                                {
                                    m_nSourcePoint += m_nBounusPoint;
                                    break;
                                }

                            // 例外
                            default:
                                {
                                    break;
                                }
                        }

                        // 過去選択オブジェクト
                        m_mOldSelectItem = SELECT_ITEM.肉;

                        break;
                    }

                // 例外
                default:
                    {
                        break;
                    }

            }
        }
        else
        {
            m_bEndSelect = true;
        }
    }

    // 更新スイッチ
    public void SetUpdateSwitch(bool bUpdate)
    {
        m_bUpdate = bUpdate;
    }

    // 色渡し
    private void SetSourceColor()
    {
        m_pSourceColorComponent.SetSourceColor(m_pColor);
    }

    // スコア渡し
    public  int  GetSelectScore()
    {
        return m_nSourcePoint;
    }

    // 選択終了
    public  bool GetSelectEndFlag()
    {
        return m_bEndSelect;
    }


    // ==========================================================================
    //                                基本関数
    // ==========================================================================
    // 初期化
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント
        m_pSourceColorComponent = m_pSourceObject.GetComponent<Source_Color>();

        // 初期化
        m_mOldSelectItem = SELECT_ITEM.無し;
        m_nSourcePoint = m_nSelectCount = 0;
        m_pColor = m_pDefaultColor;
        m_bUpdate = false;
        m_bEndSelect = false;

        // 色渡し
        SetSourceColor();

        // 加算α値計算
        m_fAddAlfa = (1.0f - m_pDefaultColor.a) / (int)(SELECT_ITEM.MAX - 1);
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // 更新許可があった時
        if(m_bUpdate)
        {
            // 色渡し
            SetSourceColor();
        }
    }
}
