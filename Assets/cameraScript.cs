using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

    GameObject myPlayer;
    public Vector3 offset;
    private float objectScale;

    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        objectScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        objectScale = Vector3.Magnitude(myPlayer.GetComponent<Collider>().bounds.size);
        Vector3 pVec = myPlayer.transform.position;
        transform.LookAt(new Vector3(pVec.x, pVec.y, pVec.z) +offset);
        transform.position = new Vector3(pVec.x, pVec.y+1, pVec.z - objectScale);
	}
}
