using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour {

	public Rail rail;

	private int currentSeg;
	private float transition;
	private bool isCompleted;
	
	// Update is called once per frame
	void Update () {
		if (!rail) {
			return;
		}

		if (!isCompleted) {
			rail.SetInitialNode (this.transform);
			Play ();
		}
	}

	public void SetRail(Rail _rail){
		Debug.Log ("set rail");
		rail = _rail;
		isCompleted = false;
		currentSeg = 0;
	}

	private void Play(){
		transition += Time.deltaTime * 1 / 1f;
		if (transition > 1) {
			transition = 0;
			currentSeg++;
			if (currentSeg >= rail.Length () - 1) {
				isCompleted = true;
				rail.ResetInitialNode ();
				return;
			}
		} else if (transition < 0) {
			transition = 1;
			currentSeg--;
		}

		transform.position = rail.LinearPosition (currentSeg, transition);
		transform.rotation = rail.LinearRotation (currentSeg, transition);


	}
}
