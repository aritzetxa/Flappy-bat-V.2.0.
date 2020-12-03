using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {
	public Transform camara;
	public Transform murcielago;
	float orthoSize;
	Vector3 lento = new Vector3(0,2.5f,0);
	// Use this for initialization
	void Start () {
		orthoSize = GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		camara.position = new Vector3(murcielago.position.x + (1.6f * GetComponent<Camera>().GetComponent<Camera>().orthographicSize / 0.9f * 0.8f), camara.position.y, camara.position.z);
		while (murcielago.position.y > (camara.position.y + (orthoSize * 0.32))) {
			camara.localPosition = camara.localPosition + (lento * Time.deltaTime);
		}
		while (murcielago.position.y < (camara.position.y - (orthoSize * 0.32))) {
			camara.localPosition = camara.localPosition - (lento * Time.deltaTime);
		}
	}
}
