using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour {
	PoolingSystem pool;
	public GameObject murcielago;
	GameObject mu;
	GameObject murci;
	GameObject camara; 
	Text text;
	Text text1;
	Text text2;
	Text winText;
	Image GOFondo;
	Renderer planeMat;

	// Use this for initialization
	void Start () {
		camara = GameObject.Find ("Main Camera");
		pool = PoolingSystem.Instance;
		murci = pool.InstantiateAPS("Nyan Bat", murcielago.GetComponent<Transform>().position, murcielago.GetComponent<Transform>().rotation);
		mu = murci;
		camara.GetComponent<cam> ().murcielago = murci.transform;
		text = GameObject.Find ("Text").GetComponent<Text> ();
		text1 = GameObject.Find ("Text1").GetComponent<Text> ();
		text2 = GameObject.Find ("Text2").GetComponent<Text> ();
		winText = GameObject.Find ("WinText").GetComponent<Text> ();
		GOFondo = GameObject.Find ("GOFondo").GetComponent<Image>();
		planeMat = GameObject.Find ("WinPlane").GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && mu.GetComponent<Colision>().muerto)
		{
			if (transform.childCount >= 2) {
				Transform[] t = GetComponentsInChildren<Transform> ();
				t [1].gameObject.DestroyAPS ();
				t [1].gameObject.GetComponent<Rigidbody2D> ().simulated = true;
				t [1].gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
				t [1].gameObject.tag = "Player";
				t [1].transform.parent = GameObject.Find("onda").transform;
				t [1].transform.parent = transform;
			}
			murci = pool.InstantiateAPS("Nyan Bat", murcielago.GetComponent<Transform>().position, murcielago.GetComponent<Transform>().rotation);
			murci.GetComponent<Animator> ().Play ("Nyan vuelo");
			text.enabled = false;
			text1.enabled = false;
			text2.enabled = false;
			GOFondo.enabled = false;
			mu.GetComponent<Colision> ().muerto = false;
			camara.GetComponent<cam> ().murcielago = murci.transform;
			mu = murci;
		} else if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 0){
			Time.timeScale = 1;
			winText.enabled = false;
			text1.enabled = false;
			text2.enabled = false;
			Color color = planeMat.material.color;
			color.a = 0f;
			planeMat.material.color = color;
			mu.transform.position = transform.position;
			mu.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);

		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene("menu");
		}
	}
}
