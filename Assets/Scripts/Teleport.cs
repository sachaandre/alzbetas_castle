using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {


    [SerializeField]
    private Transform posArr;

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
            StartCoroutine(TeleportLaunch());
        }
    }

    IEnumerator TeleportLaunch()
    {
        yield return new WaitForSeconds(0.3f);
        myPos.position = posArr.position;
    }
}
