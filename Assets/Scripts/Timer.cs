using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	public Image fillBar;
	public float maxTime = 5f;
	private float currentTime;
	public bool timerUp = false;
	// Use this for initialization
	void Start () {
		currentTime = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerUp == false) {
			currentTime = currentTime - Time.deltaTime;
			fillBar.fillAmount = currentTime / maxTime;
			if (currentTime <= 0) {
				timerUp = true;
			}
		}
	}

	public void resetTime(float _maxTime){
		maxTime = _maxTime;
		currentTime = maxTime;
		timerUp = false;
	}
}
