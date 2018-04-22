using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

	public bool done = false;
	public GameManager manager;
	Animator anim;
	public GameObject startPanel;
	// Use this for initialization
	void Start(){
		anim = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Destroy (startPanel);
			anim.SetTrigger ("StartCountDown");
		}

		if (done) {
			manager.gameRunning = true;
			Destroy (this.gameObject);
		}
	}
}
