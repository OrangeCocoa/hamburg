using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    private bool sceneChanged = false;

    public static int score;
    
    [SerializeField]
    GameObject scoreText;

    void Awake()
    {
        AcbManager.Instance.LoadCueSheet("Result", Star.Result.Result.ResultBGM);

        if (scoreText) scoreText.GetComponent<Text>().text = score.ToString();
    }

    void Update()
    {
        if (sceneChanged) return;
        if (Input.GetMouseButtonDown(0))
        {
            SceneChangerScript.Instance.SceneChangeImmediate("title");
            sceneChanged = true;
        }
    }

    void FixedUpdate()
    {

    }
}
