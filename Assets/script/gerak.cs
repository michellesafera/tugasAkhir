using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gerak : MonoBehaviour {
	public static int score;
	Text infonyawa, infokoin;

	public int kecepatan,kekuatanLompat;

	public bool balik;
	public int pindah;

	Rigidbody2D lompat;

	public bool tanah;
	public LayerMask targetLayer;
	public Transform deteksitanah;
	public float jangkauan;

	Animator anim;

	public int nyawa;
	public int koin;

	Vector2 mulai;

	public bool ulang;

	public bool tombolKiri, tombolKanan, tombolLompat;

	public GameObject menang, kalah;

	// Use this for initialization
	void Start () {
		score = 0;
		infonyawa = GameObject.Find ("Textnyawa").GetComponent<Text> ();

		infokoin = GameObject.Find ("Textkoin").GetComponent<Text> ();

		lompat = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		mulai = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		infonyawa.text = "nyawa = "+nyawa.ToString();

		infokoin.text = "koin = "+koin.ToString();

		if (ulang == true) {
			transform.position = mulai;
			ulang = false;
		}

		if (tanah == true) {
			//pada saat menyentuh tanah, mainkan animasi diam
			anim.SetBool ("lompat", false); 
		} else {
			//pada saat tidak menyentuh tanah, mainkan animasi lompat
			anim.SetBool ("lompat", true);
		}

		if (nyawa == 0) {
			if(koin>PlayerPrefs.GetInt("score"))
				PlayerPrefs.SetInt ("score",koin);
			Destroy (gameObject);
			kalah.SetActive (true);
			SceneManager.LoadScene ("menu");
		}else if (koin >= 16) {
			if(koin>PlayerPrefs.GetInt("score"))
				PlayerPrefs.SetInt ("score",koin);
			menang.SetActive (true);
			SceneManager.LoadScene ("menu");
		}

		if (Input.GetKey (KeyCode.D) || (tombolKanan == true)) {
			//mainkan aplikasi lari 
			anim.SetBool ("lari", true);
			transform.Translate (Vector2.right * kecepatan * Time.deltaTime);
			pindah = 1;
		} else if (Input.GetKey (KeyCode.A) || (tombolKiri == true)) {
			anim.SetBool ("lari", true);
			transform.Translate (Vector2.right * -kecepatan * Time.deltaTime);
			pindah = -1;
		} else if (tombolLompat == true) {
			tekanLompat ();
		} else {
			//pada saat diam
			anim.SetBool ("lari", false);
		}

//		

		if (pindah > 0 && !balik) {
			balikbadan ();
		} else if (pindah < 0 && balik) {
			balikbadan ();
		}
	}

	void balikbadan(){
		balik = !balik;
		Vector3 karakter = transform.localScale;
		karakter.x *= -1;
		transform.localScale = karakter;
	}

	void OnCollisionStay2D (Collision2D coll) {
		tanah = true;
	}

	void OnCollisionExit2D (Collision2D coll) {
		tanah = false;
	}

	public void tekankiri(){
		tombolKiri = true;
	}

	public void lepaskiri(){
		tombolKiri = false;
	}

	public void tekankanan(){
		tombolKanan = true;
	}

	public void lepaskanan(){
		tombolKanan = false;
	}

	public void tekanLompat(){
		tombolLompat = true;
		if (tanah) {
			lompat.AddForce (new Vector2 (0, kekuatanLompat));
			
		}
	}

	public void lepaslompat(){
		tombolLompat = false;
	}

}
