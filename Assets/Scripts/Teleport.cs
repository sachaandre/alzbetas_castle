using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    [SerializeField]
    private float posDep;
    [SerializeField]
    private float posArr;

    private GameObject myPlayer;
    private Transform myPos;


    // Use this for initialization
    void Start () {
        myPlayer = GameObject.Find("player");
        myPos = myPlayer.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Blowing")
        {
            Debug.Log("Hit");
        }
    }
}
