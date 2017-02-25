using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour {
    public static AdManager Instance { set; get; }
    public string banner, intersticial;
	// Use this for initialization
	void Start () {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(banner,intersticial);
        Admob.Instance().loadInterstitial();
        AdManager.Instance.showBanner();
#endif
    }
    public void showBanner()
    {
        #if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner,AdPosition.TOP_RIGHT,5);
#endif
    }
    public void showIntersticial()
    {
        #if UNITY_EDITOR
#elif UNITY_ANDROID
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
#endif
    }
    public void exitBanner()
    {
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().removeBanner();
#endif
    }
}
