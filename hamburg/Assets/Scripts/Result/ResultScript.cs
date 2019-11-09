using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    private bool sceneChanged = false;

    public static int score;
    
    [SerializeField]
    GameObject scoreText;

    [SerializeField]
    Image image;
    [SerializeField]
    Sprite[] yes;

    int scoregre = 0;

    void Awake()
    {
        AcbManager.Instance.LoadCueSheet("Result", Star.Result.Result.ResultBGM);

        if (scoreText) scoreText.GetComponent<Text>().text = score.ToString();

        if (score > 5000) scoregre = 3;
        if (4000 < score && score <= 5000) scoregre = 2;
        if (3000 < score && score <= 4000) scoregre = 1;
        if (score <= 3000) scoregre = 0;

        image.overrideSprite = yes[scoregre];
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
