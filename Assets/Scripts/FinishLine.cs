using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem finisgEffect;
    [SerializeField] float reloadTime = 2f;

    /*private void Start()
    {
        finisgEffect.Stop();
    }*/
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (player)
        {
            finisgEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", reloadTime);
        }
        else
        {
            Debug.Log("Finish!");
        }
               
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

   
}
