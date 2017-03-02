using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject explotion;
	public GameObject playerExplotion;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
			return;

        if(explotion!=null)
        Instantiate(explotion, transform.position, transform.rotation);

		if (other.tag == "Player") {
			Instantiate (playerExplotion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		//gameController.AddScore (scoreValue);
		Instantiate (explotion, this.transform.position, this.transform.rotation);
		Destroy (other.gameObject);
		Destroy (this.gameObject);


	}
}
