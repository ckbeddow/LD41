using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	public int maxSpeed = 4;
	public int acceration = 3;
	public int turnSpeed = 20;
	public float speed;
	public WordManager wordManager;
	public Trick[] tricks;
	public bool canGrind;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (wordManager.typingEnabled == false) {
			float moveX = Input.GetAxisRaw ("Horizontal");
			float moveY = Input.GetAxisRaw ("Vertical");
			if (moveY > 0) {
				speed += acceration * Time.deltaTime;
				if (speed >= maxSpeed) {
					speed = maxSpeed;
				}
			}
			if (moveY < 0) {
				speed -= acceration * Time.deltaTime;
				if (speed < 0) {
					speed = 0;
				}
			}

			if (moveX > 0) {
				transform.Rotate (Vector3.forward, -turnSpeed * Time.deltaTime);
			}

			if (moveX < 0) {
				transform.Rotate (Vector3.forward, turnSpeed * Time.deltaTime);
			}
			//Vector2 movement = new Vector2 (moveX, moveY).normalized;
			this.transform.Translate (Vector3.up * speed * Time.deltaTime);

			if(Input.GetKeyDown("space")){
				Ollie ();
			}
		}
	}


	//Hard code a bunch of tricks in here instead of using a scriptable object
	//Probably should fix if going to continue with this game after the jam

	private void Ollie (){

		//perhaps this needs a corouti
		//This is the most simple trick that is performed with a jump in open area. 
		//Default trick
		//3 word challange
		wordManager.SpawnWordChallange (3, 5f);
		//Time Limit here
		//Start countdown

		//If successful score

		//Else failure (maybe minus score????)

	}

	private void pipeGrind (){

		wordManager.SpawnWordChallange (5, 9f);


	}
}
