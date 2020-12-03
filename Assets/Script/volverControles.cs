using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class volverControles : MonoBehaviour
{
    public Button volver;


    void Start()
    {
        Button btnc = volver.GetComponent<Button>();
        btnc.onClick.AddListener(volverC);


    }
    void volverC()
    {
        SceneManager.LoadScene("menu");
    }
}