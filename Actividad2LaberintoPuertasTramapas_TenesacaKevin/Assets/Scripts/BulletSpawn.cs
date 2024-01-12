using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawn;
    [SerializeField] private bool isShooting = false;
    [SerializeField] private bool start = false;
    [SerializeField] private float bulletSpeed;
    public float intervaloBala=3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isShooting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            StartCoroutine(Shoot());
            isShooting = false;
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject x = Instantiate(bullet, spawn.position, Quaternion.identity) as GameObject;
            Rigidbody rb = x.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.back * bulletSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(intervaloBala);
        }
    }
}
