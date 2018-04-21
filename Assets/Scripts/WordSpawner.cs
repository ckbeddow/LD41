using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

	public GameObject wordPrefab;
	public GameObject wordCanvas;

	private void Start(){
		wordCanvas.SetActive (false);
	}
	public WordDisplay SpawnWord(){
		wordCanvas.SetActive (true);
		GameObject wordObj = Instantiate (wordPrefab, wordCanvas.transform);
		WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
		return wordDisplay;
	}



	public void despawnCanvas(){
		WordDisplay[] words = wordCanvas.GetComponentsInChildren<WordDisplay>();
		foreach (WordDisplay word in words) {
			word.RemoveWord ();
		}
		wordCanvas.SetActive (false);
	}
}
