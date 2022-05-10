using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class gunfire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Vector3 bulletForce;
    [SerializeField] float force;
    public AudioSource tick;

    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        tick = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            tick.Play();
        }
    }

    private void fixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = rotateAmount * Time.deltaTime;
    }

        void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(bulletForce);
        Destroy(bullet, 1f);
    }
}
