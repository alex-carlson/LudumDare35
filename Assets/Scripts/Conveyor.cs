using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float speedup = LevelGenerator.roundTime / 300;
        transform.Translate(0, 0,  -0.2f-speedup);
	}
}
