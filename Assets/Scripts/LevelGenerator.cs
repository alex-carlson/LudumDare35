using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour {

    public static Text score;
    public static Text highScore;
    public static float roundTime;
    public GameObject platform;
    public Transform instPos;

	// Use this for initialization
	void Start () {
        //DontDestroyOnLoad(transform.gameObject);
        Invoke("setObjects", 1.2f);
        score = GameObject.Find("Score").GetComponent<Text>();
        highScore = GameObject.Find("HighScore").GetComponent<Text>();
        instPos = GameObject.Find("PlacePosition").transform;
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore.text = "Best: " + (int)(PlayerPrefs.GetFloat("highscore") * 100.0f) / 100.0f;
        }
        else
        {
            highScore.text = "Best: 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        roundTime = Time.timeSinceLevelLoad;
        score.text = "Score: "+  (int)(roundTime * 100.0f) / 100.0f;
    }

    void setObjects()
    {
        GameObject thisObj = GameObject.Find("Level Geometry").transform.GetChild(0).gameObject;
        thisObj.transform.position = GameObject.Find("PlacePosition").transform.position;
        thisObj.transform.SetAsLastSibling();
        float speedup = roundTime / 200;
        Invoke("setObjects", 0.6f - speedup);
    }

    public void quitGame()
    {
        Application.Quit();
    }


    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    
    public void clearStats()
    {
        PlayerPrefs.DeleteKey("highscore");
        highScore.text = "Best: 0";
    }

}
