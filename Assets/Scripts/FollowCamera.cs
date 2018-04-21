using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public GameObject target;

	float offsetX;
	float offsetY;


	// Use this for initialization
	void Start () {
		offsetX = this.transform.position.x - target.transform.position.x;
		offsetY = this.transform.position.y - target.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = new Vector3 (target.transform.position.x + offsetX, target.transform.position.y + offsetY, -10);
		this.transform.position = Vector3.Slerp (this.transform.position, targetPosition, .1f);
	}
}
