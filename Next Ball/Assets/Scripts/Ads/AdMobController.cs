using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdMobController : MonoBehaviour {

	BannerView banner;
	InterstitialAd fullAdMob;

	public void Start(){
		string appId = "ca-app-pub-1903277593620016/2470728823";

		MobileAds.Initialize (appId);
		this.RequestBanner ();
		this.RequestFull ();
	}
	void RequestBanner(){
		string bannerId = "ca-app-pub-1903277593620016/7124289700";
		banner = new BannerView (bannerId, AdSize.SmartBanner, AdPosition.Bottom);
		AdRequest adRequest = new AdRequest.Builder ().Build ();
		banner.LoadAd (adRequest);
	}

	public void ShowBanner(){
		banner.Show ();
	}

	void RequestFull(){
		string idFull = "ca-app-pub-1903277593620016/2470728823";
		fullAdMob = new InterstitialAd (idFull);
		AdRequest adRequest = new AdRequest.Builder ().Build ();
		fullAdMob.LoadAd (adRequest);
	}

	public void ShowFullAds(){
		if (fullAdMob.IsLoaded ()) {
			fullAdMob.Show ();
			RequestFull ();
		} else {
			RequestFull ();
		}
	}
}
