using UnityEngine;

public class TitleScript : MonoBehaviour
{
    #region param
    private bool sceneChanged = false;
    #endregion

    void Awake()
    {
        AcbManager.Instance.LoadCueSheet("Title", Star.Title.Title.TitleBGM);
    }

    void Update()
    {
        if (sceneChanged) return;
        if (Input.GetMouseButtonDown(0))
        {
            SceneChangerScript.Instance.SceneChangeImmediate("MeatSelectScene");
            sceneChanged = true;
        }
    }
}
