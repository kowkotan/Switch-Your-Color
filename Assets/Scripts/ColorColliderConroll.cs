using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorColliderConroll : MonoBehaviour {

	public float verticalMin = 6f;
	public float verticalMax = 10f; 

	public List<GameObject> pinkColliders = new List<GameObject>();
	public List<GameObject> purpleColliders = new List<GameObject>();
	public List<GameObject> tealColliders = new List<GameObject>();
	public List<GameObject> yellowColliders = new List<GameObject>();
	public List<GameObject> publicObstacleObjectList;

	public Vector3 originalObstaclePosition = new Vector3(0f, 0f, 0f);
	private Vector3 newPoolPos = new Vector3(0f, 0f, 0f); 

	private int numOfObstacles;
	public int currentlySelectedObstacle;
	private List<GameObject> obstacleObjects = new List<GameObject>();  

	private GameObject starPool, colorChangePool;
	private ObjectPoolScript starPoolScript, colorChangePoolScript;  

	PlayerControll playerC;

	void Start () {
		playerC = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControll> ();

		pinkColliders.AddRange (GameObject.FindGameObjectsWithTag("PinkCollider"));
		purpleColliders.AddRange (GameObject.FindGameObjectsWithTag("PurpleCollider"));
		tealColliders.AddRange (GameObject.FindGameObjectsWithTag("TealCollider"));
		yellowColliders.AddRange (GameObject.FindGameObjectsWithTag("YellowCollider"));

		obstacleObjects.AddRange(GameObject.FindGameObjectsWithTag("ObstacleObject"));

		numOfObstacles = obstacleObjects.Count;

		publicObstacleObjectList = new List<GameObject>();

		for (int i = 0; i < numOfObstacles; i++)
		{
			GameObject obj = obstacleObjects[i];
			publicObstacleObjectList.Add(obj);
			obj.SetActive(false);
		}
		starPool = GameObject.FindGameObjectWithTag("StarPool");

		colorChangePool = GameObject.FindGameObjectWithTag("ColorChangePool");

		starPoolScript = starPool.GetComponent<ObjectPoolScript>();

		colorChangePoolScript = colorChangePool.GetComponent<ObjectPoolScript>();

		publicObstacleObjectList.Sort(SortByName);

		IncrementObstacleProgression();

		IncrementObstacleProgression();

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

	public void GetObstacle(int obstacleNum, bool rotateObstacle, float starPosDifference, float colorPosDifference)
	{
		float randDis = Random.Range(verticalMin, verticalMax);

		publicObstacleObjectList[obstacleNum].SetActive(false);

		float newDis = verticalMin * 0.5f;

		originalObstaclePosition.z = 0f;

		originalObstaclePosition.y += randDis;

		publicObstacleObjectList[obstacleNum].transform.position = originalObstaclePosition;

		if (rotateObstacle) {

			publicObstacleObjectList [obstacleNum].transform.eulerAngles = new Vector3 (0f, 0f, 90f);

			publicObstacleObjectList [obstacleNum].SetActive (true);

			newPoolPos = originalObstaclePosition;

			GetStarObject(newPoolPos, starPosDifference);

			GetColorChangerObject(newPoolPos, newDis + colorPosDifference);

		} else {
			publicObstacleObjectList [obstacleNum].transform.eulerAngles = new Vector3 (0f, 0f, 0f);

			publicObstacleObjectList [obstacleNum].SetActive (true);

			newPoolPos = originalObstaclePosition;

			GetStarObject(newPoolPos, starPosDifference);

			GetColorChangerObject(newPoolPos, newDis + colorPosDifference);

		}

	}

	public void GetStarObject(Vector3 newPos, float yOffset)
	{
		GameObject obj = starPoolScript.GetPooledObject();

		if (obj == null) return;

		obj.transform.position = newPos + new Vector3(0, yOffset, 0);
		obj.transform.rotation = Quaternion.identity;
		obj.SetActive(true);
	}

	public void GetColorChangerObject(Vector3 newPos, float Dis)
	{
		GameObject obj = colorChangePoolScript.GetPooledObject();

		if (obj == null) return;

		obj.transform.position = newPos + new Vector3( 0, Dis /** 0.5f*/, 0 );
		obj.transform.rotation = Quaternion.identity;
		obj.SetActive(true);
	}

	public void IncrementObstacleProgression()
	{
		bool shouldWeRotateObstacle;

		if(playerC.playerColor == PlayerColors.Teal || playerC.playerColor == PlayerColors.Pink)
		{
			shouldWeRotateObstacle = false;
		}
		else
		{
			shouldWeRotateObstacle = true;
		}
		if (currentlySelectedObstacle >= publicObstacleObjectList.Count)
		{
			currentlySelectedObstacle = 0;
		}

		switch (currentlySelectedObstacle)
		{
		case 0:
			GetObstacle (currentlySelectedObstacle , false, 0f , 0f );
			break;
		case 1:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 2:
			GetObstacle(currentlySelectedObstacle, false, 2f, 0f);
			break;
		case 3:
			GetObstacle(currentlySelectedObstacle, shouldWeRotateObstacle, 0f, 0f);
			break;
		case 4:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 5:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 6:
			GetObstacle(currentlySelectedObstacle, false, 1.5f, 0f);
			break;
		case 7:
			GetObstacle(currentlySelectedObstacle, shouldWeRotateObstacle, 0f, 0f);
			break;
		case 8:
			GetObstacle(currentlySelectedObstacle, false, 3f, 0f);
			break;
		case 9:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 10:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 11:
			GetObstacle(currentlySelectedObstacle, false, 0f, 2.75f);
			break;
		case 12:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 13:
			GetObstacle(currentlySelectedObstacle, false, 2f, 0f);
			break;
		case 14:
			GetObstacle(currentlySelectedObstacle, false, 3f, 0f);
			break;
		case 15:
			GetObstacle(currentlySelectedObstacle, false, 2f, 0f);
			break;
		case 16:
			GetObstacle(currentlySelectedObstacle, shouldWeRotateObstacle, 0f, 0f);
			break;
		case 17:
			GetObstacle(currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 18:
			GetObstacle(currentlySelectedObstacle, false, 2f, -0.5f);
			break;
		case 19:
			GetObstacle(currentlySelectedObstacle, false, 1f, 3.25f);
			break;
		case 20:
			GetObstacle (currentlySelectedObstacle, false, 0f, 0f);
			break;
		case 21:
			GetObstacle(currentlySelectedObstacle, false, 1.25f, 0f);
			break;

		default:
			break;
		}
			
		currentlySelectedObstacle++;


	}

	private static int SortByName(GameObject obstacle1, GameObject obstacle2)
	{
		return obstacle1.name.CompareTo(obstacle2.name);
	}
}
