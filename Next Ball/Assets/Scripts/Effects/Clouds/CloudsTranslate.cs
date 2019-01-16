using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsTranslate : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		this.transform.Translate ((Vector2.left * Time.deltaTime)*.2f);


		if (this.transform.position.x <= -8.1) {
			Destroy (this.gameObject);
		}
	}
}
