using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    ParticleSystem ps;
    public GameObject finishEffect;
    somersaultDetecter somersaultDetecterScript;
    void Start()
    {
        somersaultDetecterScript = FindObjectOfType<somersaultDetecter>();
        ps = finishEffect.GetComponent<ParticleSystem>();
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            ps.Play();
            StartCoroutine(waitForFinish());
        }
    }
    IEnumerator waitForFinish()
    {
        somersaultDetecterScript.levelIsActive = false;
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(0);
    }

}
