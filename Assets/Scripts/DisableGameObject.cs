using UnityEngine;
using System.Collections;

public class DisableGameObject : MonoBehaviour {

    public float delay;

	void Start () 
	{
        Invoke("DisableObj", delay);
	}

    void DisableObj()
    {
        this.gameObject.SetActive(false);
    }
}
