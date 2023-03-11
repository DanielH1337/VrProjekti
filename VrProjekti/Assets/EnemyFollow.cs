using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public GameObject GameOverText;
    public Transform VRcamera;
    public float speed=0.1f;
    bool gameOverCheck = true;
    public Material EnemyDeadMaterial;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        enemy.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);

        if(enemy.remainingDistance < 0.5f && enemy.remainingDistance > 0)
        {
          //  Debug.Log(enemy.remainingDistance);
            GameOver();
            gameOverCheck = false;
               
        }
    }
    private void GameOver()
    {
        if (gameOverCheck)
        {
            Instantiate(GameOverText, VRcamera.position + (VRcamera.forward * 5), VRcamera.rotation);
            Time.timeScale = 0f;
            
        }
  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            gameObject.GetComponent<MeshRenderer>().material = EnemyDeadMaterial;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            wall.GetComponent<WallDisappearScript>().isFading = true;
        }
    }
   

}
