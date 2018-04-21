using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public Transform end;

	void OnTrigger2DEnter(Collider2D other){
		if (other.tag == "Player") {
			PlayerController player = other.GetComponent<PlayerController> ();
			player.canGrind = true;
		}
	}

	void OnTrigger2DExit(Collider2D other){
		if (other.tag == "Player") {
			PlayerController player = other.GetComponent<PlayerController> ();
			player.canGrind = false;
		}
	}
}
