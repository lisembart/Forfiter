using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using admob;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance { set; get; }

    [Header("AdMob Settings")]
    public string bannerID;
    public string interstitialID;

    private string currentSceneName;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
    }

    void Start()
    {
        Debug.Log("AdMob Starting");
        Instance = this;
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(bannerID, interstitialID);
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
        Admob.Instance().setTesting(false);
#endif
        if(currentSceneName == "Menu")
        {
            ShowBannerMenu();
        } else if(currentSceneName == "Game")
        {
            DontShowAds();
        }
    }

    public void ShowBannerMenu()
    {
        if (currentSceneName == "Menu")
        {
#if UNITY_EDITOR
            Debug.Log("Showing banner");
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 1);
#endif
        }
    }

    public void DontShowAds()
    {
#if UNITY_EDITOR
        Debug.Log("Not showing banner");
#elif UNITY_ANDROID
        Admob.Instance().removeAllBanner();
#endif
    }

    public void ShowBannerGameOver()
    {
#if UNITY_EDITOR
        Debug.Log("Showing banner Game Over");
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 1);
#endif
    }
}
