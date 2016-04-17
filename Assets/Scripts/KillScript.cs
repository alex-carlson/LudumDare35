using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class KillScript : MonoBehaviour {

    float distort = 0;
    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("highscore", Time.timeSinceLevelLoad);
            StartCoroutine("warpScreen");
            Invoke("die", 1f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator warpScreen()
    {
        GetComponent<AudioSource>().clip = deathSound;
        GetComponent<AudioSource>().Play();
        GameObject.Find("Main Camera").transform.parent = GameObject.Find("Level Geometry").transform;

        while (distort < 1.5f)
        {
            distort += 0.1f;
            //GameObject.Find("Main Camera").GetComponent<Fisheye>().strengthX = distort;
            //GameObject.Find("Main Camera").GetComponent<Fisheye>().strengthY = distort;
            yield return new WaitForEndOfFrame();
        }
    }

    void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
