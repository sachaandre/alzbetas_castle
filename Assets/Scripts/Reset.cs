using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour{

	// VARIABLES
	[SerializeField]
	private int scIndex;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			SceneManager.LoadScene(scIndex);
		}
	}
}
