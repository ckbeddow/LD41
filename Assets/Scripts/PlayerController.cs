using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Rigidbody2D rb;
	RailMover rMover;
	CircleCollider2D col;
	public int maxSpeed = 4;
	public int acceration = 3;
	public int turnSpeed = 20;
	public float speed;
	public WordManager wordManager;
	public Trick[] tricks;
	public bool canGrind;
	public bool falling = false;
	Animator anim;
	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//rb = GetComponent<Rigidbody2D> ();
		rMover = GetComponent<RailMover>();
		col = GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (falling) {
			anim.SetBool ("isFalling", true);
		} else {
			anim.SetBool ("isFalling", false);
		}

		if (wordManager.typingEnabled == true) {
			col.isTrigger = true;
		}
		if (wordManager.typingEnabled == false && falling == false && gameManager.gameRunning == true) {
			col.isTrigger = false;
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
				RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up, 1f);
				if (hit.collider != null) {
					Debug.Log ("Hit space");
					Debug.Log (hit.transform.tag);
					if (hit.transform.tag == "Pipe") {
						Pipe pipe = hit.transform.GetComponent<Pipe> ();
						Debug.Log ("HIT PIPE");
						Debug.Log (pipe.canGrind (this.transform));
						if (pipe.canGrind (this.transform)) {
							pipeGrind (pipe.rail);
						}
					} else if (hit.transform.tag == "HalfPipe") {
						Pipe pipe = hit.transform.GetComponent<Pipe> ();
						if (pipe.canGrind (this.transform)) {
							halfPipeFlip (pipe.rail);
						}
					}
				}else {
					Ollie ();
				}

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
		wordManager.SpawnWordChallange (3, 5f, "Ollie");
		anim.SetTrigger ("Ollie");

		//Time Limit here
		//Start countdown

		//If successful score

		//Else failure (maybe minus score????)

	}

	private void pipeGrind (Rail rail){

		rMover.SetRail (rail);
		wordManager.SpawnWordChallange (4, 6f, "Railslide");


	}

	private void halfPipeFlip (Rail rail){
		rMover.SetRail (rail);
		wordManager.SpawnWordChallange (6, 9f, "Half Pipe Spin");
	}

	public void Failed (){
		Debug.Log ("failed");

		falling = true;

		// Failure spash 
		gameManager.Failed ();
	}
}
