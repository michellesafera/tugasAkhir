using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Score = "+gerak.score.ToString();
	}
}
