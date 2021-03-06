﻿using UnityEngine;
using System.Collections;

public class LitOff : MonoBehaviour {

	[SerializeField]
	private int lampIndex;
	private bool isBlown;
	private Animator lAnimator;
	private GameObject lamp;
    private GameObject spotlight;
	// Use this for initialization
	void Start ()
	{
		lAnimator = GetComponent<Animator> ();
		lamp = GameObject.Find ("Lamp[" + lampIndex + "]");
        spotlight = lamp.transform.Find("Spotlight").gameObject;
	}

	void Update(){
		setOffAnimation ();
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Blowing") 
		{
			lAnimator.SetBool ("blown", true);
			isBlown = lAnimator.GetBool ("blown");
			Debug.Log (isBlown);
		}
	}

	private void setOffAnimation(){
		if (isBlown) {
			lAnimator.SetBool ("off", true);
			lamp.tag="LightOff";
            spotlight.SetActive(false);
		}
	}
}