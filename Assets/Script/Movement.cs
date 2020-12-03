using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movement = 4f;
    public float jump = 4f;
    public bool jumpEnabled = true;
	public AudioClip audioFlap;
	public AudioClip audioScream;
	private AudioSource audioS;
    Transform murcielago;
    Rigidbody2D rb;

	Transform onda;
	bool lanza = false;

	void Start()
    {
		audioS = GetComponent<AudioSource> ();
        rb = GetComponent<Rigidbody2D>();
		murcielago = GetComponent<Transform> ();
		onda = GameObject.Find ("onda").GetComponent<Transform> ();
    }

    void Update()
    {
        rb.velocity = new Vector2(movement, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && jumpEnabled == true && gameObject.tag == "Player" && Time.timeScale > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
			audioS.clip = audioFlap;
			audioS.volume = 1f;
			audioS.Play ();
        }
		if (!lanza && gameObject.tag == "Player" && GetComponent<Colision>().muerto == false){
			onda.localPosition = new Vector3( murcielago.position.x - 9f, onda.localPosition.y, onda.localPosition.z);
		} else if(lanza && gameObject.tag == "Player" && GetComponent<Colision>().muerto == false) {
			if (onda.position.x > murcielago.position.x + 40f){
				onda.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
				onda.position = new Vector3 (murcielago.position.x - 9f, onda.position.y, onda.position.z);
				lanza = false;
			}
			onda.position = new Vector3 (onda.position.x, murcielago.position.y, onda.position.z);
		}
		if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown("enter") || Input.GetKeyDown(KeyCode.Return)) && gameObject.tag == "Player" && GetComponent<Colision>().muerto == false && Time.timeScale > 0)
        {
			lanza = true;
			audioS.clip = audioScream;
			audioS.volume = 0.1f;
			audioS.Play ();
			onda.position = new Vector3(murcielago.position.x + 4f, onda.position.y, onda.position.z);
			onda.GetComponent<Rigidbody> ().velocity = new Vector3 (movement * 10f, 0, 0);
		}
    }
}