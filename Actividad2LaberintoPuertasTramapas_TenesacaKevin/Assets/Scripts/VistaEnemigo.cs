using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vigilante : MonoBehaviour
{
    [SerializeField] float longitudrayo = 15f;
    public LayerMask ElementoQueVeo;
    [SerializeField] Transform ojos;
    private bool mirandoIzquierda = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Vigilancia());
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        Vector3 direction = ojos.forward; // Cambiado a ojos.forward
        Vector3 target = (ojos.position + (direction * longitudrayo));
        RaycastHit hit; // Variable name corrected
        if (Physics.Raycast(ojos.position, direction, out hit, longitudrayo, ElementoQueVeo)) // Variable name corrected
        {
            // Do something when the ray hits an object
        }
        else
        {
            Debug.DrawLine(ojos.position, target, Color.white);
        }
    }


    IEnumerator Vigilancia()
    {
        while (true)
        {
            if (mirandoIzquierda)
            {
                for (int i = 0; i < 20; i++)
                {
                    transform.Rotate(Vector3.up, 1);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                for (int i = 0; i < longitudrayo; i++)
                {
                    transform.Rotate(Vector3.up, -1);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            mirandoIzquierda = !mirandoIzquierda;
            yield return new WaitForSeconds(2.0f);
        }
    }

}
