using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public Button jugar;
    public Button creditos;
    public Button controles;
    public Button salir;

    void Start()
    {
        Button btn = jugar.GetComponent<Button>();
        btn.onClick.AddListener(inicioDeJuego);

        btn = creditos.GetComponent<Button>();
        btn.onClick.AddListener(credits);

        btn = controles.GetComponent<Button>();
        btn.onClick.AddListener(controls);

        btn = salir.GetComponent<Button>();
        btn.onClick.AddListener(exit);
    }
    void inicioDeJuego()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene("movimiento");
    }
    void credits()
    {
        SceneManager.LoadScene("creditos");
    }
    void controls()
    {
        SceneManager.LoadScene("controles");
    }
    void exit()
    {
        Application.Quit();
    }
}