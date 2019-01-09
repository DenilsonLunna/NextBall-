using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBall : MonoBehaviour{
	private int damage;
	public Text damageTxt;
	public int points;
	void Update(){
		this.transform.Rotate (new Vector3 (0, 0, 2));// effect
		damageTxt.transform.Rotate (new Vector3 (0, 0, -2));// effect

	}
	void Start(){
		damage = Random.Range (1, 5); // adicionando vida da bola
		points = damage; // os pontos que a bola vai dar, vai ser a quantidade do dano dela
		//this.transform.localScale = new Vector2((40 + damage),(40 + damage)); // definindo tamanho da bola com seu damage como base
		this.GetComponent<Rigidbody2D> ().drag = (damage * 0.1f)+(damage*0.05f); // definindo  velocidade que o obstaculo vai cair
		damageTxt.text = damage.ToString();//colocando o dano da bola para aparecer no canvas
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (!GameObject.Find ("ReferencePoint").GetComponent<BallThrower> ().instanciou) { // resolvendo bug 1
			if (col.tag == "Ball") {// se colidir com outra bola aliada
				if (damage == 0) {
					newPoint ();
					Destroy (this.gameObject);
				}
				damageTxt.text = damage.ToString ();
			}
		}
		
	}
		

	void newPoint(){
		//ajustar isso
		Game_Model gm = GameObject.Find ("Game Model").GetComponent<Game_Model> ();
		int p = gm.bestPoint; // capturando os pontos atuais
		p += points;
		PlayerPrefs.SetInt ("pointsInGame",p);
		gm.attBestPoint(p); // adicionando mais um ponto
		p = gm.amountBalls + points;
		gm.attAmountBalls(p); // adicionando mais bolas para o jogador

	}


	public void reduceHeath(int damage){
		this.damage -= damage;
	}



	public int getDamage(){
		return damage;
	}
	public void setDamage(int dam){
		damage = dam;
	}
	public int getLife(){
		return damage;
	}
	public void setLife(int l){
		damage = l;
	}
}
