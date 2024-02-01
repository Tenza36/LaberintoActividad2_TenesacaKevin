using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DeteccionPj : MonoBehaviour
{
    [SerializeField] float longitudrayo = 15f;
    public LayerMask ElementoQueVeo;
    private bool mirandoIzquierda = false;
    public Transform target;
    public float speed = 5.0f;
    public bool persecucion = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Vigilancia());
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
        if (persecucion == true)
        {
            Persecucion();
        }
       
    }

    private void Raycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * longitudrayo, Color.red);
        if (Physics.Raycast(ray, out hit, longitudrayo, ElementoQueVeo) && persecucion == false ) // Variable name corrected
        {
            Persecucion();


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
    void Persecucion()
    {
        Vector3 direction = target.position - transform.position;

        // Normaliza la dirección (la convierte en un vector de longitud 1)
        direction.Normalize();

        // Calcula la nueva posición del personaje
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

        // Mueve el personaje a la nueva posición
        transform.position = newPosition;
        persecucion = true;

    } 

}