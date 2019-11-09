
using UnityEngine;

public class InGameScript : MonoBehaviour
{
    private bool sceneChanged = false;

    void Awake()
    {
        AcbManager.Instance.LoadCueSheet("Game", Star.Game.Game.InGameBGM);
    }

    private void Update()
    {

        if (sceneChanged) return;
        if (Input.GetButtonDown("Jump"))
        {
            SceneChangerScript.Instance.SceneChangeImmediate("result");
            sceneChanged = true;
        }
    }
}
