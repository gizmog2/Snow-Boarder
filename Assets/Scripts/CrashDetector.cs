using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float reloadTime = 1f;
    [SerializeField] AudioClip crashSFX;
    bool isTouching = false;
    

    /*private void Start()
    {
        crashEffect.Stop();
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !isTouching)
        {
            isTouching = true;
            FindObjectOfType<PlayerController>().StopControl();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);            
            Invoke("ReloadScene", reloadTime);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
