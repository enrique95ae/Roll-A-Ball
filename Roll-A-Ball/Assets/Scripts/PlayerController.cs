using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 
 * CREDIT TO:
 *  
 *  -UNITY tutorials. Roll-A-Ball tutorial.
 *  Multiple audio sources: https://support.unity3d.com/hc/en-us/articles/206116386-How-do-I-play-multiple-Audio-Sources-from-one-GameObject-
 *  Audio on pick ups: https://www.youtube.com/watch?v=GdkDLNbht_I
 * 
 * 
 */


public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private AudioSource pickUpAudio;
    private AudioSource winAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        AudioSource[] audioSources = GetComponents<AudioSource>();
        pickUpAudio = audioSources[0];
        winAudio = audioSources[1];
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            pickUpAudio.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 16)
        {
            winText.text = "You win!";
            winAudio.Play(0);

        }
    }
}
