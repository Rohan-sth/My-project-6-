using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class balloona : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    [SerializeField] Vector3 force;
    Vector3 temp;
    private Rigidbody2D rb;
    public AudioSource tickSource;
    


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(Random.Range(-11f, 11f), Random.Range(4f, -3.8f), transform.position.z);
        force = new Vector3(Random.Range(-50, 50), Random.Range(80, 120), 0);

        rb.AddForce(force);
        tickSource = GetComponent<AudioSource> ();
    }


    void Update()
    {
        temp = transform.localScale;

        temp.x += 0.001f;
        temp.y += 0.001f;

        transform.localScale = temp;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            
            tickSource.Play();
            anim.Play("popanimation");
            Destroy(gameObject, 3f);
            Scorescript.scoreValue += 10;
            GoToScene();
        }
    }

    void GoToScene()
    {
        Time.timeScale = Time.deltaTime * 10f;
        SceneManager.LoadScene(2);

    }
}
