
public class AcbManager : SingletonMonoBehavior<AcbManager>
{
    public CriAtom atom;
    public string beforeBGMCueSheetName { get; private set; }

    private CriAtomSource bgmSource = default;
    private CriAtomSource seSource = default;
    private float bgmVolume = 1f;
    private float seVolume = 1f;

    void Awake()
    {
        SetInstance(this);
    }

    public void LoadAcf()
    {
        beforeBGMCueSheetName = "";

        atom = gameObject.AddComponent<CriAtom>();
        atom.acfFile = "Star.acf";

        CriAtom.AddCueSheet("Common", "Common.acb", null, null);
        seSource = gameObject.AddComponent<CriAtomSource>();
        seSource.cueSheet = "Common";
        seSource.volume = seVolume = 1f;

        bgmSource = gameObject.AddComponent<CriAtomSource>();
        bgmSource.cueSheet = beforeBGMCueSheetName;
        bgmSource.volume = bgmVolume = 1f;
    }

    public void LoadCueSheet(string cueSheetName, int bgmCueId)
    {
        CriAtom.RemoveCueSheet(beforeBGMCueSheetName);
        beforeBGMCueSheetName = cueSheetName;
        CriAtom.AddCueSheet(beforeBGMCueSheetName, beforeBGMCueSheetName + ".acb", null, null);
        bgmSource.cueSheet = beforeBGMCueSheetName;
        bgmSource.volume = bgmVolume;
        bgmSource.Play(bgmCueId);
    }

    public void SetVolume(float bgmVol, float seVol)
    {
        // 0.0f ~ 1.0f
        bgmVolume = bgmVol;
        seVolume = seVol;
    }

    public void PlaySE(int seCueId)
    {
        seSource.Play(seCueId);
    }
}
