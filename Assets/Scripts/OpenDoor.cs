using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	private Animator doorAnimator;
	private int nbLampOn;
	private GameObject door;

	// Use this for initialization
	void Start () {
		doorAnimator = GetComponent<Animator>();
		door = GameObject.Find("Door");
	}

	// Update is called once per frame
	void Update () {
		nbLampOn = GameObject.FindGameObjectsWithTag("LightOn").Length;
		verifyLightOff();
	}

	private void verifyLightOff(){
		if(nbLampOn == 0) {
			doorAnimator.SetBool("open", true);
			door.tag = "open";
		}
	}
}
