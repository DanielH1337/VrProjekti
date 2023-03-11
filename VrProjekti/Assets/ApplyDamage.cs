using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Apply Damage to balloon
        
        collision.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        if (collision.gameObject.CompareTag("balloon"))
        {
            ScoreManager.instance.AddPoint();
        }
        
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
  
}
