using UnityEngine;
using System.Collections;

public class ObstSpawner : MonoBehaviour {

    public Transform spawnpoint;
    public GameObject[] obsts;

	// Use this for initialization
	void Start () {
        int count = GameObject.Find("Obstacles").transform.childCount;
        for (int i = 0; i < count; i++)
        {
            obsts[i] = GameObject.Find("Obstacles").transform.GetChild(i).gameObject;
            int r = Mathf.RoundToInt(Random.Range(0, count));
            GameObject.Find("Obstacles").transform.GetChild(r).transform.SetAsLastSibling();
        }
        Invoke("spawnThing", 0);
	}
	
	void spawnThing()
    {
        float speedup = LevelGenerator.roundTime / 300;
        GameObject thisGO = GameObject.Find("Obstacles").transform.GetChild(0).gameObject;
        float r = Random.Range(-10, 10);

        thisGO.transform.position = spawnpoint.position + new Vector3(r, 0, 0);
        thisGO.transform.SetAsLastSibling();
        Invoke("spawnThing", 3f - speedup);
    }
}
