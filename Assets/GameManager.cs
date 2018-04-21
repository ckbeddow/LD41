using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text scoreText;
	public int score = 0;

	public void Score(int _score){
		score += _score;
		scoreText.text = "Score: " + score;
	}



}
