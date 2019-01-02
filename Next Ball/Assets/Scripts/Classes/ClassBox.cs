using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBox{
	private int life;

	public virtual void Effect(GameObject[] balls){}

	public int getLife(){
		return life;

	}
	public void setLife(int l){
		if (l >= 0) {
			this.life = l;
		}
	}
}
