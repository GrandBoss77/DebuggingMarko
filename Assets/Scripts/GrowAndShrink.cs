using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{
    [SerializeField] float grow = 0.2f;
    [SerializeField] float shrink = 0.2f;

    public void Grow()
    {
        transform.localScale = new Vector3((transform.localScale.x + grow) , (transform.localScale.y + grow), 1f);
    }

    public void Shrink()
    {

    }

}
