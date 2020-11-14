using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperTriggerAutoActivationScript : MonoBehaviour
{
    public float inputDuration = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(FlipperAutoActivation());
        }
    }

    IEnumerator FlipperAutoActivation()
    {
        float t = 0f;

        while(t < inputDuration)
        {
            transform.parent.GetComponent<FlippersInputScript>().ActivateFlipper();
            t += Time.deltaTime;
            yield return null;
        }        
    }
}
