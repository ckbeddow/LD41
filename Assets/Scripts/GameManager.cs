﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI timerText;
	public int score = 0;
	public float timeRemaining;
	public float startingTime;
	public Animator failedTextAnim;
	public TextMeshProUGUI successText;
	public Animator successTextAnim;
	public GameObject endScreen;
	public GameObject pauseScreen;

	public bool gameRunning = false;


	public void Score(int _score){
		score += _score;
		scoreText.text = "Score: " + score;
		successText.text = "+" + _score;
		successTextAnim.SetTrigger ("Score");
	}

	private void Start(){
		timeRemaining = startingTime;
	}
	private void Update(){

		if (gameRunning) {

			if (Input.GetKeyDown(KeyCode.Escape)) {
				Pause ();

			}

			timeRemaining -= Time.deltaTime;
			if (timeRemaining <= 0) {
				timeRemaining = 0;
				gameRunning = false;
				endScreen.SetActive (true);
			}
			float minutes = Mathf.Floor (timeRemaining / 60);
			int seconds = Mathf.RoundToInt(timeRemaining % 60);
			string secondsString;
			if (seconds < 10) {
				secondsString = "0" + seconds.ToString();
			} else {
				secondsString = seconds.ToString();
			}
			timerText.text = "Time: " + minutes + ":" + secondsString;


		}

	}

	public void Failed(){
		failedTextAnim.SetTrigger ("FailedText");
	}

	public void ReturnToMenu(){
		
		SceneManager.LoadScene (0);

	}
	public void Pause (){
		gameRunning = false;
		pauseScreen.SetActive (true);
	}

	public void UnPause(){
		gameRunning = true;
		pauseScreen.SetActive (false);
	}

}
