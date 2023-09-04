using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobBannerSystem : MonoBehaviour
{
    private BannerView banner;
    [SerializeField] private string adUnitId = "ca-app-pub-3940256099942544/6300978111";
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        ShowBanner();
    }
    private void ShowBanner()
    {
        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        banner = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);
    }
}
