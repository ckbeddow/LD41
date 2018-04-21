using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public Transform end;
	public Rail rail;

	public bool canGrind(Transform player){
		Debug.Log (player.rotation.z);

		//NEED TO GET ROTATION IN QUATERNIAN
		if (player.rotation.z >= 90f || player.rotation.z <= -90f) {
			
			return true;
		}

		return false;
	}
}
