using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour {

	public TextMeshProUGUI scoreText;
	public GameManager gm;
	void Start(){
		scoreText.text = gm.score.ToString();
	}
	
	public void LoadMenu(){
		SceneManager.LoadScene (0);
	}

	public void Retry(){
		SceneManager.LoadScene (1);
	}
}
