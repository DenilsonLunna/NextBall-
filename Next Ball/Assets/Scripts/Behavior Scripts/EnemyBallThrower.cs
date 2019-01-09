using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallThrower : MonoBehaviour {
	private float time;
	public float timeForChangePositionAndThrow;
	public List<GameObject> obstaculos;
	private int tamList;

	// Use this for initialization
	void Start () {
		time = 0;
		tamList = obstaculos.Count;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;


		if (time > timeForChangePositionAndThrow) {
			this.transform.localPosition = new Vector3 (Random.Range (-2f, 2f), this.transform.position.y,88f);
			this.Throw ();
			time = 0;
		}

	}

	void Throw(){
		//============ Instanciando Obstaculos
		GameObject obs =  Instantiate (obstaculos [Random.Range(0,tamList)], this.transform.position, Quaternion.identity);

		//=========== Preciso fazer isso para que o texto da vida da bola apareça na canvas
		obs.transform.SetParent (GameObject.Find ("Canvas").transform);
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Ball") {
			Destroy (col.gameObject);
			time = timeForChangePositionAndThrow +1;
		}

	}
}
