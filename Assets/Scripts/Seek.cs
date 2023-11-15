using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seek : MonoBehaviour
{
    [SerializeField] float checkPlayerRadius;


    public void Start()
    {
    }

    void FixedUpdate()
    {
        //Check for wall
        LayerMask collisionLayers = LayerMask.GetMask("Player");
        bool playerDetect = Physics2D.OverlapCircle(transform.position, checkPlayerRadius, collisionLayers);

        if (playerDetect)
        {
            GameObject moveTowardsThis = GameObject.FindWithTag("Player");
            transform.position = Vector3.MoveTowards(transform.position, moveTowardsThis.transform.position, 0.07f);
        }
        else
        {
            //transform.position = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0); 
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if(collider.gameObject.TryGetComponent(out GrowAndShrink otherblobs))
        {
            otherblobs.Grow();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position, checkPlayerRadius);
    }
}
