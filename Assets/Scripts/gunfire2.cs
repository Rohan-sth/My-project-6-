using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfire2 : MonoBehaviour
{
    [SerializeField] GameObject pinPrefab;
    [SerializeField] Vector3 pinForce;
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

        GameObject pin = Instantiate(pinPrefab, transform.position, transform.rotation);
        pin.GetComponent<Rigidbody2D>().AddRelativeForce(pinForce);
        Destroy(pin, 1f);
    }
}
