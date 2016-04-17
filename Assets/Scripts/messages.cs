using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class messages : MonoBehaviour {

    public string[] words;
    public AudioClip[] sounds;

	// Use this for initialization
	void Start () {
        InvokeRepeating("sendMessage", 20f, 20f);
	}

    void sendMessage()
    {
        StartCoroutine("fadeIn");
    }

    IEnumerator fadeIn()
    {
        int r1 = Mathf.RoundToInt(Random.Range(0, words.Length));
        int r2 = Mathf.RoundToInt(Random.Range(0, sounds.Length));
        Text myText = GetComponent<Text>();

        myText.text = words[r1];
        GetComponent<AudioSource>().clip = sounds[r2];

        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1);
        myText.text = "";
    }
}
