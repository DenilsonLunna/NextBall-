using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingTheColor : MonoBehaviour {
	public SpriteRenderer backgroundColor;
	public float r = 0f;
	public float g = 0f;
	public float b = 150;

	
	// Update is called once per frame
	void Start() {
		StartCoroutine ("rotina");
		backgroundColor.color = new Color (r, g,b );
	}


	IEnumerator rotina()
	{
		while (true) {
			
			r++;
			if (r == 255f) {
				Debug.Log ("acavou no 255)");
				r = 0f;
			}
		
			backgroundColor.color = new Color (r, g,b );
			Debug.Log (r);
		}
	}
	IEnumerator rotina2(){
		
		while (true) {			
			yield return new WaitForSeconds (15);
			g=Random.Range(0f,255f);

			backgroundColor.color = new Color (r, g,b );
			Debug.Log ("mudou o g");
		}
	}
	IEnumerator rotina3(){
		
		while (true) {
			yield return new WaitForSeconds (30);
			b= Random.Range(0f,255f);

			backgroundColor.color = new Color (r, g,b );
			Debug.Log ("mudou o b");

		}
	}
}
