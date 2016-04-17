using UnityEngine;
using System.Collections;
using Rewired;

public class playerController : MonoBehaviour {

    [Range(1, 1000)] public float speed = 1;
    [Range(1, 100)] public float turnamt = 1;
    private Player player;
    public MeshFilter[] shapes;
    public Color[] colors;
    private MeshFilter myFilter;
    private int currShape = 0;
    private Animator anim;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(0); // get the Rewired Player
        myFilter = GetComponentInChildren<MeshFilter>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = player.GetAxis("Horizontal");
        bool shift = player.GetButtonDown("Shapeshift");
        //transform.Rotate(new Vector3(0, h*turnamt, 0));
        //transform.Translate(h, 0, spd * speed);

        rb.AddForce(h * turnamt, 0, 0);


        if (shift)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool("Morph", true);
            } else
            {
                anim.SetBool("Morph", false);
            }
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
        GetComponent<AudioSource>().Play();
    }

    void idle()
    {
        myFilter.GetComponent<MeshRenderer>().material.color = colors[currShape];
        transform.rotation = Quaternion.Euler(Vector3.zero);
        anim.SetBool("Morph", false);
    }

}
