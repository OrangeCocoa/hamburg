using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ソースの色変え
public class Source_Color : MonoBehaviour
{
    // ==========================================================================
    //                               メンバ変数
    // ==========================================================================
    // 変数
    private SpriteRenderer      m_pSpriteRendererComponent;     // スプライトレンダラーコンポーネント


    // ==========================================================================
    //                               メンバ関数
    // ==========================================================================
    // 色変え
    public  void SetSourceColor(Color   pSourceColor)
    {
        // コンポーネントの取得ができているなら
        if (m_pSpriteRendererComponent != null)
        {
            m_pSpriteRendererComponent.color = pSourceColor;
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
        m_pSpriteRendererComponent = GetComponent<SpriteRenderer>();
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        
    }
}
