using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchItem : MonoBehaviour {

	PlayerControll playerC;
	ColorColliderConroll c;

	void Start () {
		playerC = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControll> ();
		c = GameObject.FindGameObjectWithTag ("ColorColliderControll").GetComponent<ColorColliderConroll> ();
	}

	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player")) {
			SwitchColor ();
		}
	}

	public void SwitchColor(){
		playerC.SwitchColors ();
		c.ChangeColorColliderState ();

		gameObject.SetActive (false);
	}
}
