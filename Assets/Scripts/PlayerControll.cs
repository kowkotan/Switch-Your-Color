using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColors{
	Pink, Purple, Teal, Yellow
};

public class PlayerControll : MonoBehaviour {

	Rigidbody playerRB;
	Camera mainCam;
	Renderer playerRenderer;

	public PlayerColors playerColor;
	public Color[] arrayOfColors;
	public Color originalColor;
	public int numOfColors;
	public ForceMode upwardForceMode;
	public float upwardForce;
	public GameObject deathParticles, flashObject; 

	void Awake(){
		playerRB = GetComponent<Rigidbody> ();
		playerRB.useGravity = false;
		playerRenderer = GetComponentInChildren<Renderer> ();
		playerColor = (PlayerColors)Random.Range(0, System.Enum.GetValues(typeof(PlayerColors)).Length);
		playerRenderer.material.color = arrayOfColors [(int)playerColor];
		mainCam = Camera.main;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			playerRB.useGravity = true;
			playerRB.AddForce (Vector3.up * upwardForce, upwardForceMode);
			//playerRB.velocity = Vector3.up * upwardForce;
		}
	}

	public void SwitchColors(){
		//playerColor += 1;
		//int playerColorsInt = (int)playerColor;
		//if (playerColorsInt == numOfColors) {
			//playerColor = 0;
		//}

		playerColor = (PlayerColors)Random.Range(0, System.Enum.GetValues(typeof(PlayerColors)).Length);
		playerRenderer.material.color = arrayOfColors [(int)playerColor];

		switch (playerColor) {
		case PlayerColors.Pink:
			playerRenderer.material.color = arrayOfColors [0];
			break;
		case PlayerColors.Purple:
			playerRenderer.material.color = arrayOfColors [1];
			break;
		case PlayerColors.Teal:
			playerRenderer.material.color = arrayOfColors [2];
			break;
		case PlayerColors.Yellow:
			playerRenderer.material.color = arrayOfColors [3];
			break;

		default:
			break;
		}
	}

	void OnCollisionEnter(Collision col){
		PlayerDeathEffects ();
		//Invoke("ShowEndGameCanvasAndScore", 1.75f);
	}

	public void PlayerDeathEffects()
	{
		Instantiate(deathParticles, transform.position, transform.rotation);
		Instantiate(flashObject, transform.position + new Vector3(0, 7f, 0), transform.rotation);
		gameObject.SetActive(false);
		//isPlayerDead = true;
	}
}
