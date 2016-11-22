using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Variables
	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	//Vars for blow action
	private bool blow;
	private GameObject blowingCircle;

	//jump vars
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	private bool isGrounded;
	private bool jump;
	[SerializeField]
	private bool airControl;
	[SerializeField]
	private float jumpForce;

	[SerializeField]
	private int movementSpeed;

	private bool facingRight;

	// Use this for initialization
	void Start (){
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		facingRight = true;
		blowingCircle= GameObject.Find("blow");
		blowingCircle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update (){
		HandleInput();
	}

	void FixedUpdate(){
		float horizontal = Input.GetAxis("Horizontal");
		isGrounded = IsGrounded();
		HandleMovement(horizontal);
		Flip (horizontal);
		HandleBlow();
		ResetValues();
	}

	private void HandleMovement(float horizontal){
		if ( isGrounded || airControl) {
			myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);
		}
		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

		if (isGrounded && jump) {
			isGrounded = false;
			myRigidbody.AddForce (new Vector2 (0, jumpForce));
			myAnimator.SetTrigger ("jump");
		}
		if (myRigidbody.velocity.y < 0) {myAnimator.SetBool ("land", true);}
	}

	private void HandleInput(){
		if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space)){
			jump=true;
		}

		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.LeftControl)){
			blow=true;
		}
	}

	private void HandleBlow(){
		if (blow) {
			myAnimator.SetTrigger("blow");
			myRigidbody.velocity = Vector2.zero;
			blowingCircle.SetActive(true);
			StartCoroutine (blowingOff ());
		} 

	}

	private bool IsGrounded(){
		if(myRigidbody.velocity.y == 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
				for(int i = 0; i < colliders.Length; i++) {
					if(colliders[i].gameObject != gameObject) {
						myAnimator.ResetTrigger ("jump");
						myAnimator.SetBool ("land", false);
						return true;
					}
				}
			}
		}
		return false;
	}

	private void Flip(float horizontal){
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
			ChangeDirection ();
		}
	}

	public void ChangeDirection(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1,1,2);
	}

	public void ResetValues(){
		jump=false;
		blow=false;
	}

		IEnumerator blowingOff(){
		yield return new WaitForSeconds (0.3f);
		blowingCircle.SetActive(false);
		myAnimator.ResetTrigger("blow");
	}

}

