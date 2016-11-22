using UnityEngine;
using System.Collections;

public class Ennemy : MonoBehaviour {

	[SerializeField]
	private Vector3 posA;
	[SerializeField]
	private Vector3 posB;

	private Vector3 nexPos;
	[SerializeField]
	private Transform ePos;

	[SerializeField]
	private float speed;
	private bool facingRight;

	// Use this for initialization
	public void Start () {
		facingRight = true;
		nexPos = posB;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		eMove ();
		SetNexPos ();
	}

	private void eMove(){
		ePos.localPosition = Vector3.MoveTowards(ePos.localPosition,nexPos,speed);
	}

	private void SetNexPos(){
		if (ePos.localPosition == nexPos && nexPos == posB) {
			nexPos = posA;
			ChangeDirection ();
		} else if (ePos.localPosition == nexPos && nexPos == posA) {
			nexPos = posB;
			ChangeDirection ();
		}
	}

	public void ChangeDirection(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1,1,2);
	}
}