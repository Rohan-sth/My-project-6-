using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloonc : MonoBehaviour
{
    [SerializeField] Vector3 force;
    Vector3 temp;
    private Rigidbody2D rb;
    public AudioSource tick;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(Random.Range(-11f, 11f), Random.Range(4f, -3.8f), transform.position.z);
        force = new Vector3(Random.Range(-50, 50), Random.Range(80, 120), 0);

        rb.AddForce(force);
        tick = GetComponent<AudioSource>();


    }


    void Update()
    {
        temp = transform.localScale;

        temp.x += 0.0001f;
        temp.y += 0.0001f;

        transform.localScale = temp;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {

            Destroy(gameObject, 0.1f);
            tick.Play();
            Scorescript.scoreValue += 10;
            PlayerManager.isGameOver = true;
            //GoToScene();
        }
    }

    void GoToScene()
    {
        Time.timeScale = Time.deltaTime * 10f;
        SceneManager.LoadScene(2);

    }
}
