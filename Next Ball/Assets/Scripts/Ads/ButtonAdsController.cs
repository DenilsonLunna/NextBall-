using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAdsController : MonoBehaviour {
	public void MostrevideoPremiado (){
		AdsController.instancia.MostrevideoPremiado ();
	}
	public void MostreVideoNormal()
	{
		AdsController.instancia.Mostrevideo ();
	}
}
