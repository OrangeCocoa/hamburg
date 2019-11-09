using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    #region param
    private bool sceneChanged = false;

    public float score { get; set; } = 0;
    [SerializeField]
    GameObject scoreText;
    #endregion

    void Awake()
    {
        AcbManager.Instance.LoadCueSheet("Result", Star.Result.Result.ResultBGM);

        if (scoreText) scoreText.GetComponent<Text>().text = score.ToString();
    }

    void Update()
    {
        if (sceneChanged) return;
        if (Input.GetButtonDown("Jump"))
        {
            SceneChangerScript.Instance.SceneChangeImmediate("title");
            sceneChanged = true;
        }
    }

    void FixedUpdate()
    {

    }
}
