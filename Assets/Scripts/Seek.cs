using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seek : MonoBehaviour
{
    [SerializeField] float checkPlayerRadius;
    
    private RandomMoveMent randomMoveMent;

    public void Start()
    {
        randomMoveMent = GetComponent<RandomMoveMent>();
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
            randomMoveMent.enabled = false;
        }
        else
        {
            randomMoveMent.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Damage damage))
        {
            damage.ResetGame();
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
