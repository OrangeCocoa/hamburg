using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UIスイッチ
public class UI_Switch : MonoBehaviour
{
    // 外部入力値
    [SerializeField]
    private GameObject m_pManagerObject;
    private Game_Manager m_pManagerComponent;
    [SerializeField]
    private GameObject m_pSelectObject;
    [SerializeField]
    private GameObject m_pMixObject;


    // Start is called before the first frame update
    void Start()
    {
        m_pManagerComponent = m_pManagerObject.GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_pManagerComponent.GetGAME_MODE() == Game_Manager.GAME_MODE.SOZAI_ERABI)
        {
            m_pSelectObject.SetActive(true);
        }
        else
        {
            m_pSelectObject.SetActive(false);
        }

        if (m_pManagerComponent.GetGAME_MODE() == Game_Manager.GAME_MODE.KAKI_MAZE)
        {
            m_pMixObject.SetActive(true);
        }
        else
        {
            m_pMixObject.SetActive(false);
        }
    }
}
