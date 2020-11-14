using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButScript : MonoBehaviour
{
    public GameObject launcher;
    public float timerWaitANewBall;
    LancementBalleScript lancementBalleScript;

    private void Start()
    {
        lancementBalleScript = launcher.GetComponent<LancementBalleScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            StartCoroutine(WaitForANewBall(timerWaitANewBall));
        }
    }

    public IEnumerator WaitForANewBall(float _timer)
    {
        yield return new WaitForSeconds(_timer);

        lancementBalleScript.newball(lancementBalleScript.bille, lancementBalleScript.launcher, lancementBalleScript.puissance);
    }
}
