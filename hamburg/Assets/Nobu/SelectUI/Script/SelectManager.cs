using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;

    public static uint nCnt;
    public static uint nMeatCnt;
    public static uint nVegetableCnt;
    public static uint nSourceCnt;

    // Start is called before the first frame update
    void Awake()
    {
        nCnt = 0;
        nMeatCnt = 0;
        nVegetableCnt = 0;
        nSourceCnt = 0;
        Image1.gameObject.SetActive(false);
        Image2.gameObject.SetActive(false);
        Image3.gameObject.SetActive(false);
        Image4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick(int number)
    {

        switch (number)
        {
            case 1:
                if(Image1.gameObject.activeSelf==false)
                {
                    Image1.gameObject.SetActive(true);
                    nCnt += 1;
                }
                else
                {
                    Image1.gameObject.SetActive(false);
                    nCnt -= 1;
                }
                break;
            case 2:
                if (Image2.gameObject.activeSelf == false)
                {
                    Image2.gameObject.SetActive(true);
                    nCnt += 2;
                }
                else
                {
                    Image2.gameObject.SetActive(false);
                    nCnt -= 2;
                }
                break;
            case 3:
                if (Image3.gameObject.activeSelf == false)
                {
                    Image3.gameObject.SetActive(true);
                    nCnt += 3;
                }
                else
                {
                    Image3.gameObject.SetActive(false);
                    nCnt -= 3;
                }
                break;
            case 4:
                if (Image4.gameObject.activeSelf == false)
                {
                    Image4.gameObject.SetActive(true);
                    nCnt += 4;
                }
                else
                {
                    Image4.gameObject.SetActive(false);
                    nCnt -= 4;
                }
                break;


            case 5://NEXTボタン処理
                if (SceneManager.GetActiveScene().name == "MeatSelectScene" && nCnt!=0)
                {
                    nMeatCnt = nCnt;
                    SceneManager.LoadScene("VegetableSelectScene");
                }
                if (SceneManager.GetActiveScene().name == "VegetableSelectScene" && nCnt != 0)
                {
                    nVegetableCnt = nCnt;
                    SceneManager.LoadScene("SourceSelectScene");
                }
                if (SceneManager.GetActiveScene().name == "SourceSelectScene" && nCnt != 0)
                {
                    nSourceCnt = nCnt;
                    SceneChangerScript.Instance.SceneChangeImmediate("Hamburger_sauce");
                    //SceneManager.LoadScene("MeatSelectScene");
                }
                break;
            default:
                break;
        }
    }

    public static uint GetMeatCnt()
    {
        return nMeatCnt;
    }

    public static uint GetVegetableCnt()
    {
        return nVegetableCnt;
    }

    public static uint GetSourceCnt()
    {
        return nSourceCnt;
    }

}
