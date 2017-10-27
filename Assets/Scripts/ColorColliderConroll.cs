using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorColliderConroll : MonoBehaviour {

	public List<GameObject> pinkColliders = new List<GameObject>();
	public List<GameObject> purpleColliders = new List<GameObject>();
	public List<GameObject> tealColliders = new List<GameObject>();
	public List<GameObject> yellowColliders = new List<GameObject>();

	PlayerControll playerC;

	void Start () {
		playerC = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControll> ();

		pinkColliders.AddRange (GameObject.FindGameObjectsWithTag("PinkCollider"));
		purpleColliders.AddRange (GameObject.FindGameObjectsWithTag("PurpleCollider"));
		tealColliders.AddRange (GameObject.FindGameObjectsWithTag("TealCollider"));
		yellowColliders.AddRange (GameObject.FindGameObjectsWithTag("YellowCollider"));

		ChangeColorColliderState ();
	}

	public void ChangeColorColliderState(){
		for (int i = 0; i < tealColliders.Count; i++)
		{
			var item = tealColliders[i];
			item.GetComponent<MeshCollider>().enabled = true;
		}
			
		for (int i = 0; i < pinkColliders.Count; i++)
		{
			var item = pinkColliders[i];
			item.GetComponent<MeshCollider>().enabled = true;
		}

		for (int i = 0; i < purpleColliders.Count; i++)
		{
			var item = purpleColliders[i];
			item.GetComponent<MeshCollider>().enabled = true;
		}

		for (int i = 0; i < yellowColliders.Count; i++)
		{
			var item = yellowColliders[i];
			item.GetComponent<MeshCollider>().enabled = true;
		}

		if (playerC.playerColor == PlayerColors.Pink) {
			for (int i = 0; i < pinkColliders.Count; i++) {
				var item = pinkColliders [i];
				item.GetComponent<MeshCollider> ().enabled = false;
			}
		}

		if (playerC.playerColor == PlayerColors.Purple) {
			for (int i = 0; i < purpleColliders.Count; i++) {
				var item = purpleColliders [i];
				item.GetComponent<MeshCollider> ().enabled = false;
			}
		}

		if (playerC.playerColor == PlayerColors.Teal) {
			for (int i = 0; i < tealColliders.Count; i++) {
				var item = tealColliders [i];
				item.GetComponent<MeshCollider> ().enabled = false;
			}
		}

		if (playerC.playerColor == PlayerColors.Yellow) {
			for (int i = 0; i < yellowColliders.Count; i++) {
				var item = yellowColliders [i];
				item.GetComponent<MeshCollider> ().enabled = false;
			}
		}
	}
}
