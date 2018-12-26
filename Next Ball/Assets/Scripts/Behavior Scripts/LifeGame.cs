using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LifeGame : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Ball"|| col.tag == "EnemyBall") {
			newLife (col.gameObject);
			Destroy (col.gameObject);

		}


	}
	void newLife(GameObject obj){
		int damage = 0;
		//pegando o dano que vai ser causado
		if (obj.tag == "Ball") {
			damage = obj.GetComponent<Ball> ().nb.getDamage ();
		} else if (obj.tag == "EnemyBall") {
			damage = obj.GetComponent<EnemyBall> ().getDamage ();
		}
		 
		int newLife = GameObject.Find ("Game Model").GetComponent<Game_Model> ().lifeGame - damage;// configurando
		GameObject.Find ("Game Model").GetComponent<Game_Model> ().attLifeGame(newLife); // atualizando vida 
		if(newLife <= 0){
			SceneManager.LoadScene ("TryAgain");
		}
	}
}
