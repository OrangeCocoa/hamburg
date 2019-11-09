using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アイテムをドラッグし、引っ張っていく処理
public class Select_Item : MonoBehaviour
{
    // ==========================================================================
    //                               メンバ変数
    // ==========================================================================
    // 構造体
    private struct IMAGE_DATA
    {
        string name;
        Sprite ItemIcon;
    };

    // 外部入力値
    [SerializeField]
    GameObject              m_pSelectPointObject;                // ポイントオブジェクト
    Select_Point            m_pSelectPointColorComponent;        // ポイントコンポーネント
    [SerializeField]
    private IMAGE_DATA[]    Item_Icon = new IMAGE_DATA[7];

    // 変数


    // ==========================================================================
    //                               メンバ関数
    // ==========================================================================
    // マウスと当たり判定
    private void MouseHit()
    {
        // マウスボタンが押されたら
        if(Input.GetMouseButtonDown(0))
        {
            // カメラからRay照射して判定
            Ray pRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit pHitInfo = new RaycastHit();
            float fMaxDistance = 1000.0f;

            // Rayに何かが接触しているならば
            bool    bHit = Physics.Raycast(pRay, out pHitInfo, fMaxDistance);
            if (bHit)
            {
                // ポイント加算
                m_pSelectPointColorComponent.AddSourcePoints(pHitInfo.transform.name);
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
        // コンポーネント追加
        m_pSelectPointColorComponent = m_pSelectPointObject.GetComponent<Select_Point>();
    }

    // 更新
    // Update is called once per frame
    void Update()
    {
        // 選択が終わっていないなら更新
        if (!m_pSelectPointColorComponent.GetSelectEndFlag())
        {
            // マウスと当たり判定
            MouseHit();
        }
    }
}
