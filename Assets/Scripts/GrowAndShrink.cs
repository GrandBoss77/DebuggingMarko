using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{
    [SerializeField] float growAndShrink = 0.2f;
    [Header("Every GrowLevel is GrowLevel * grow")]
    [SerializeField] int maximumGrowLevel = 5;

    int scaleValue = 0;

    Coroutine currentGrowRoutine;
    Coroutine currentShrinkRoutine;

    public IEnumerator Growing()
    {
        if (scaleValue == maximumGrowLevel) { yield break; }
        else { scaleValue += 1; }
        transform.localScale = new Vector3((transform.localScale.x + growAndShrink), (transform.localScale.y + growAndShrink), 1f);
        yield return new WaitForSeconds(2);
        currentGrowRoutine = null;
    }

    public void Grow()
    {
        if(currentGrowRoutine != null) { return; }
        currentGrowRoutine = StartCoroutine(Growing());
    }

    public void Shrink()
    {
        if (currentShrinkRoutine != null) { return; }
        currentShrinkRoutine = StartCoroutine(Shrinking());
    }

    public IEnumerator Shrinking()
    {
        if (scaleValue == -1) { yield break; }
        else { scaleValue -= 1; }
        transform.localScale = new Vector3((transform.localScale.x - growAndShrink), (transform.localScale.y - growAndShrink), 1f);
        yield return new WaitForSeconds(2);
        currentShrinkRoutine = null;
    }
}
