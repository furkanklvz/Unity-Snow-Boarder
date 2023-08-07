using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashingHead : MonoBehaviour
{
    ParticleSystem ps;
    public GameObject bloodEffect;
    somersaultDetecter somersaultDetecterScript;
    void Start()
    {
        somersaultDetecterScript = FindObjectOfType<somersaultDetecter>();
        ps = bloodEffect.GetComponent<ParticleSystem>();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "head")
        {
            ps.Play();
            StartCoroutine(reloadScene());
        }
    }
    IEnumerator reloadScene()
    {
        somersaultDetecterScript.levelIsActive = false;
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
