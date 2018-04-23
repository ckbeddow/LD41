using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public Transform end;
	public Rail rail;
	public bool north;

	public bool canGrind(Transform player){
		//Debug.Log (player.rotation.z);

		//Needs work on if a certain direction can activate the grind
		/*
		if (north) {
			if (player.rotation.z >= 0.7f || player.rotation.z <= -0.7f) {
			
				return true;
			}
		} else if (!north) {
			if (player.rotation.z <= 0.7f || player.rotation.z >= -0.7f) {

				return true;
			}
		}

		return false;
		*/
		return true;
	}
}
