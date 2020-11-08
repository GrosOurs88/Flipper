using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperTriggerAutoActivation : MonoBehaviour
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
            transform.parent.GetComponent<FlippersInput>().ActivateFlipper();
            t += Time.deltaTime;

            print(t);
            yield return null;
        }        
    }
}
