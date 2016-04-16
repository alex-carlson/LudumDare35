using UnityEngine;
using System.Collections;
using Rewired;

public class playerController : MonoBehaviour {

    [Range(0, 1)] public float speed = 1;
    [Range(1, 10)] public float turnamt = 1;
    private Player player;
    public MeshFilter[] shapes;
    public Color[] colors;
    private MeshFilter myFilter;
    private int currShape = 0;
    private Animator anim;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(0); // get the Rewired Player
        myFilter = GetComponentInChildren<MeshFilter>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = player.GetAxis("Horizontal");
        float spd = player.GetAxis("Accelerate");
        bool shift = player.GetButtonDown("Shapeshift");
        transform.Rotate(new Vector3(0, h*turnamt, 0));
        transform.Translate(0, 0, spd * speed);

        if (shift)
        {
            animate();
        }
	}

    void shapeshift()
    {

        currShape++;

        if(currShape > shapes.Length-1)
        {
            currShape = 0;
        }
        myFilter.mesh = shapes[currShape].mesh;
        GetComponent<MeshCollider>().sharedMesh = shapes[currShape].mesh;
    }

    void animate()
    {

        anim.SetBool("Morph", true);
    }

    void idle()
    {
        anim.SetBool("Morph", false);
        myFilter.GetComponent<MeshRenderer>().material.color = colors[currShape];
    }
}
