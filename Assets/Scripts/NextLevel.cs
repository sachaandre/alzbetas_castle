using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	[SerializeField]
	private int sceneIndex;
	private bool playInput;

	private GameObject door;


	// Use this for initialization
	void Start () {
		door = GameObject.Find("Door");
	}

	// Update is called once per frame
	void Update () {
		playInput = Player.nexLv;
	}

	public void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player" && playInput == true && door.tag == "open"){
			SceneManager.LoadScene(sceneIndex);
		}
	}

}
