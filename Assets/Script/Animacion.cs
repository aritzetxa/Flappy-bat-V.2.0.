using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.Play("Nyan vuelo");
    }

    void Update()
    {
        GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<Colision>().muerto == false && gameObject.tag == "Player")
        {
            ani.Play("vuelo");
        }

    }
    void aniFinish()
    {
        ani.Play("Nyan vuelo");
    }
}
