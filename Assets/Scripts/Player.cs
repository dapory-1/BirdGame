using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float grabity = 10f;
    public float accel = 10f;
    float v;

    public AudioClip upSound;
    public AudioClip downSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(upSound);
        }

        if (Input.GetButtonUp("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(downSound);
        }

        if (Input.GetButton("Jump"))
        {
            v -= accel*Time.deltaTime;
        }
        else
        {
            v += grabity * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * v * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") 
        {
            float score = GameManager.Instance.score;

            PlayerPrefs.SetInt("Score",(int)score);
            PlayerPrefs.Save();

            SceneManager.LoadScene("GameOverScene");
        }
    }
}
