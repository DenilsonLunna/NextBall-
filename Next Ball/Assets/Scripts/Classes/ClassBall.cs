using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBall{
	private string nameBall;
	private int damage;
	public Sprite sprite;


	//================================================================ Construtores
	public ClassBall(){
		
	}
	public ClassBall(string name){
		this.nameBall = name;
	}
	public ClassBall(string name, int damage){
		this.nameBall = name;
		this.damage = damage;
	}
	public ClassBall(string name, int damage, Sprite sprite){
		this.nameBall = name;
		this.damage = damage;
		this.sprite = sprite;
	}



	//================================================================ Ataques especiais

	public virtual void SpecialPower(Collider2D col){}








	//================================================================ Gets e sets
	public int getDamage(){
		return damage;

	}
	public void setDamage(int dam){
		if (dam >= 0) {
			this.damage = dam;
		}
	}
	public string getName(){
		return nameBall;

	}
	public void setName(string name){
		this.nameBall = name;
	}

}
