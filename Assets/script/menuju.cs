using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class menuju : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlay()
	{
		SceneManager.LoadScene("scene1");
	}

	public void OnAbout()
	{
		SceneManager.LoadScene("aboout");
	}
}
