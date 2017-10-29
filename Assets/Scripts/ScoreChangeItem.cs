using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreChangeItem : MonoBehaviour
{
    public AudioClip scoreChangeSound;
    public float localSoundVolume;
    public Text scoreText;
    public GameObject effectToInstantiate, effectToInstantiate2;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }
		
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IncreaseScore();
        }
    }
    public void IncreaseScore()
    {
        if (scoreChangeSound)
        {
            AudioSource.PlayClipAtPoint(scoreChangeSound, transform.position, localSoundVolume * 2f);
        }
			
        Instantiate(effectToInstantiate, transform.position, transform.rotation);
        Instantiate(effectToInstantiate2, transform.position, transform.rotation);

        gameObject.SetActive(false);
    }

}
