using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public GameObject explosion;
    int c=0;

    void Start() 
    {
        explosion.SetActive(false);
    }
    void OnTriggerEnter(Collider other) 
    {
        c++;
        print(c);
        if (c>=5)
        {
          StartDeathSequence();
          Invoke("ReloadScene",1f);
        }
    }

    private void StartDeathSequence()
    {
        print("Player is dying");
        SendMessage("PlayerDeath");
        explosion.SetActive(true);
    }

    private void ReloadScene()
    {
         SceneManager.LoadScene(1);
    }

}
