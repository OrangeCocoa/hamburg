using UnityEngine;

public class InGameScript : MonoBehaviour
{
    #region param
    private bool sceneChanged = false;
    #endregion

    void Awake()
    {
        var sceneName = this.gameObject.scene.name;

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

    void FixedUpdate()
    {

    }
}
