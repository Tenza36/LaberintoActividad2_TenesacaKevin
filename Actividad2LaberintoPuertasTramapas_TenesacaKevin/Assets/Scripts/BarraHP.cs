using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraHP : MonoBehaviour
{
    public Image barraHP;
    public float vidaActual;
    public float vidaMaxima;

    void Update()
    {
        barraHP.fillAmount = vidaActual / vidaMaxima;

        if (barraHP.fillAmount <= 0)
        {
            ReiniciarEscena();
        }
    }

    public void ReiniciarEscena()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
