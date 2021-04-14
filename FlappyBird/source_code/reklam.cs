using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class reklam : MonoBehaviour
{
    private InterstitialAd interstitial;

    static reklam reklamKontrol;
    void Start()
    {
        if (reklamKontrol==null)
        {
            DontDestroyOnLoad(gameObject);
            reklamKontrol = this;
        }
        else
        {
            Destroy(gameObject);
        }


        //1.aþama---------------------------------------------------------------------
        ////oyun kimliði
        //#if UNITY_ANDROID
        //    string appId = "ca-app-pub-3116307697323224~7828591154";
        //#elif UNITY_IPHONE
        //    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        //#else
        //    string adUnitId = "unexpected_platform";
        //#endif

        MobileAds.Initialize(initStatus => { });

        //2.aþama---------------------------------------------------------------------

        //reklam geçis
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        //3.aþama---------------------------------------------------------------------

        //bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        interstitial.LoadAd(request);
        //bannerView.LoadAd(request);

        //4.aþama--------------------------------------------------------------------


    }


    public void reklamiGoster()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        reklamKontrol = null;
        Destroy(gameObject);
    }
}
