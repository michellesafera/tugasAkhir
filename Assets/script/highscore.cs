using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Highscore = "+PlayerPrefs.GetInt ("score").ToString();
	}
}
