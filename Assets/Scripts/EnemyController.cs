using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    [SerializeField] GameObject explosionEffects;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;
     [SerializeField] int scorePerHit = 10;
    void Start() 
    {
      scoreBoard = FindObjectOfType<ScoreBoard>();
    }
     void OnParticleCollision(GameObject other)  
    {
       scoreBoard.ScoreOnHit(scorePerHit);
       GameObject fx = Instantiate(explosionEffects,transform.position,Quaternion.identity);
       fx.transform.parent = parent;
       Destroy(gameObject);
       print("Hit");    
    }
}
