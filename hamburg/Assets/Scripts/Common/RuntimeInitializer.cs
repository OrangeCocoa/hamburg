using UnityEngine;

public class RuntimeInitializer : MonoBehaviour
{
    private static int screenWidth = 1800;
    private static int screenHeight = 990;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AppInitialize()
    {
        // 画面サイズ固定
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer ||
            Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Screen.SetResolution(screenWidth, screenHeight, false);
        }

        if (!CriWareInitializer.IsInitialized())
        {
            var criWareInitializer = new GameObject("CriWareLibraryInitializer").AddComponent<CriWareInitializer>();
            criWareInitializer.dontInitializeOnAwake = true;
            criWareInitializer.Initialize();
            DontDestroyOnLoad(CriWare.managerObject);
        }

        var acbManager = new GameObject("AcbManager").AddComponent<AcbManager>();
        acbManager.LoadAcf();
        acbManager.LoadCueSheet("Title", Star.Title.Title.TitleBGM);
        DontDestroyOnLoad(acbManager.gameObject);
    }
}
