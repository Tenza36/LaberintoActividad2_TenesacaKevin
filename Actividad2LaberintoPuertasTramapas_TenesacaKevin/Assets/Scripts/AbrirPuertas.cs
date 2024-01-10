using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertas : MonoBehaviour
{
    public Animator PuertasGeneral;
    public void OnTriggerEnter(Collider other)
    {
        PuertasGeneral.Play("Abrir");
    }
     public void OnTriggerExit(Collider other)
    {
        PuertasGeneral.Play("Cerrar");
    }

}
