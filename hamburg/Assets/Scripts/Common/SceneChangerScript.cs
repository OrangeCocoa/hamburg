using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangerScript : SingletonMonoBehavior<SceneChangerScript>
{
    #region param
    private static GameObject overlayCanvas = default;
    enum FadeMode : int
    {
        NONE = -1,
        FADE_IN = 0,
        FADE_OUT,
    }
    private FadeMode fadeMode = FadeMode.NONE;

    private string nextSceneName = default;

    public bool fadeEnd { get; private set; }

    private float fadeDelta = 0f;
    private float waitTime = 1f;

    public bool changingScene { get; private set; }
    #endregion

    void Awake()
    {
        SetInstance(this);

        changingScene = false;

        if (overlayCanvas)
        {
            overlayCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
            fadeMode = FadeMode.FADE_OUT;
            changingScene = true;
        }

        fadeDelta = 0f;
        fadeEnd = false;
    }

    void FixedUpdate()
    {
        switch (fadeMode)
        {
            case FadeMode.FADE_IN:
                FadeIn();
                break;

            case FadeMode.FADE_OUT:
                FadeOut();
                break;

            default:
                break;
        }

        if (!fadeEnd) return;

        if (fadeMode == FadeMode.FADE_IN)
        {
            DontDestroyOnLoad(overlayCanvas);

            SceneManager.LoadScene(nextSceneName);
        }
        if (fadeMode == FadeMode.FADE_OUT)
        {
            Destroy(overlayCanvas);
            changingScene = false;
            fadeMode = FadeMode.NONE;
        }
    }

    public void SceneChangeImmediate(string nextSceneName, List<GameObject> dontDestroyGameObjects = null)
    {
        Change(nextSceneName, dontDestroyGameObjects);
        waitTime = 1f;
    }

    private void Change(string nextSceneName, List<GameObject> dontDestroyGameObjects = null)
    {
        changingScene = true;
        this.nextSceneName = nextSceneName;

        if (dontDestroyGameObjects != null)
        {
            foreach (var go in dontDestroyGameObjects) DontDestroyOnLoad(go);
        }

        var canvas = Resources.Load("Prefabs/OverlayCanvas") as GameObject;
        overlayCanvas = Instantiate(canvas, new Vector3(0, 0, 100), Quaternion.identity);
        overlayCanvas.GetComponentInChildren<Image>().color = new Color32(255, 255, 255, 0);
        overlayCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        fadeMode = FadeMode.FADE_IN;

        fadeDelta = 0f;
        fadeEnd = false;
    }

    private void FadeIn()
    {
        var image = overlayCanvas.GetComponentInChildren<Image>();
        if (image.color.a < 1f)
        {
            image.color = Color.Lerp(new Color32(255, 255, 255, 0), new Color32(255, 255, 255, 255), fadeDelta / waitTime);
        }

        fadeDelta += Time.deltaTime;

        if (fadeDelta > waitTime) fadeEnd = true;
    }

    private void FadeOut()
    {
        var image = overlayCanvas.GetComponentInChildren<Image>();
        if (image.color.a > 0f)
        {
            image.color = Color.Lerp(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0),  fadeDelta / waitTime);
        }

        fadeDelta += Time.deltaTime;

        if (fadeDelta > waitTime) fadeEnd = true;
    }
}
