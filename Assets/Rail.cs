using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Rail : MonoBehaviour {
	private Transform[] nodes;

	// Use this for initialization
	void Start () {
		ResetNodes ();
	}

	public Vector3 LinearPosition (int seg, float ratio){
		Vector3 p1 = nodes [seg].position;
		Vector3 p2 = nodes [seg + 1].position;

		return Vector3.Lerp (p1, p2, ratio);
	}

	public Quaternion LinearRotation ( int seg, float ratio){
		Quaternion q1 = nodes [seg].rotation;
		Quaternion q2 = nodes [seg+1].rotation;

		return Quaternion.Lerp (q1, q2, ratio);


	}

	private void OnDrawGizmos(){
		for (int i = 0; i < nodes.Length - 1; i++) {
			if (!nodes [i]) {
				ResetNodes ();
				return;
			}
			Handles.DrawDottedLine (nodes [i].position, nodes [i + 1].position, 3f);
		}
	}

	public int Length(){
		return nodes.Length;
	}

	private void ResetNodes(){
		nodes = GetComponentsInChildren<Transform> ();
	}

	public void SetInitialNode(Transform transform){
		nodes [0] = transform;
	}

	public void ResetInitialNode(){
		nodes [0] = this.transform;
	}
}
