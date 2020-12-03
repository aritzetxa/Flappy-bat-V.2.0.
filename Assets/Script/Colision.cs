using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colision : MonoBehaviour {
	Text text;
	Text text1;
	Text text2;
	Text winText;
	Image GOFondo;
    Transform murcielago;
	Rigidbody2D murcielagorb;
    Animator ani;
    public bool muerto = false;
	private AudioSource audioS;
	public AudioClip audioGolpe;
	Transform onda;
	Transform camara;
	Renderer planeMat;
	Color color;
	bool transparente = false;

    void Start () {
        ani = GetComponent<Animator>();
		audioS = GetComponent<AudioSource> ();
		murcielago = GetComponent<Transform> ();
		murcielagorb = GetComponent<Rigidbody2D> ();
		text = GameObject.Find ("Text").GetComponent<Text>();
		text1 = GameObject.Find ("Text1").GetComponent<Text>();
		text2 = GameObject.Find ("Text2").GetComponent<Text>();
		winText = GameObject.Find ("WinText").GetComponent<Text> ();
		GOFondo = GameObject.Find ("GOFondo").GetComponent<Image>();
		GOFondo.enabled = false;
		onda = GameObject.Find ("onda").transform;
		camara = GameObject.Find ("Main Camera").transform;
		planeMat = GameObject.Find ("WinPlane").GetComponent<Renderer> ();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "pum" && gameObject.tag == "Player")
        {
			audioS.clip = audioGolpe;
			audioS.volume = 1f;
			audioS.Play ();
            text.enabled = true;
            ani.Play("muerte");
			muerto = true;
			murcielagorb.simulated = false;
			murcielago.GetComponent<BoxCollider2D> ().isTrigger = true;
			murcielago.tag = "dead";
			onda.position = new Vector3 (murcielago.position.x + 50f, onda.position.y, onda.position.z);
			onda.GetComponent<Rigidbody> ().velocity = new Vector3 (gameObject.GetComponent<Movement> ().movement * 10f, 0, 0);
			GOFondo.enabled = true;
			text1.enabled = true;
			text2.enabled = true;
        }
    }

	void OnTriggerEnter2D(Collider2D col){
		if (col.name == "Fin"){
			Time.timeScale = 0;
			winText.enabled = true;
			text1.enabled = true;
			text2.enabled = true;
			color = planeMat.material.color;
			transparente = true;
		}
	}
	void Update(){
		if (transparente && color.a < 1f) {
			color.a = color.a + 0.05f;
			planeMat.material.color = color;
		}
	}
}
