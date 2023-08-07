using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragging : MonoBehaviour
{
    ParticleSystem ps;
    playerController playerControllerScript;
    public GameObject skiingEffect;
    public bool onSurface = false;
    void Start()
    {
        ps = skiingEffect.GetComponent<ParticleSystem>();
        playerControllerScript = FindObjectOfType<playerController>();
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        onSurface = true;
        if (collisionInfo.otherCollider.tag == "head")
        {
            return;
        }
        ps.Play();
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        onSurface = false;
        ps.Stop();
    }
}
