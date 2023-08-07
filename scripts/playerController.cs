using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    public static int collectedDiamonds = 0;
    boost boostScript;
    dragging draggingScript;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueValue = 1f;
    [SerializeField] float boostedSpeed = 22f;
    [SerializeField] float baseSpeed = 15f;
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        boostScript = FindObjectOfType<boost>();
        draggingScript = FindObjectOfType<dragging>();
    }

    void Update()
    {
        rotate();
        if (Input.GetKey(KeyCode.W) && boostScript.boostValue > 0 && draggingScript.onSurface)
        {
            responseBoost();
            boostScript.boostValue = boostScript.boostValue - Time.deltaTime * 45;
        }else if (Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = baseSpeed/4;
        }
        else
        {
            surfaceEffector2D.speed = Mathf.Lerp(surfaceEffector2D.speed,baseSpeed,0.01f);
        }
    }

    void responseBoost()
    {
        surfaceEffector2D.speed = boostedSpeed;
    }

    void rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(torqueValue * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-torqueValue * Time.deltaTime);
        }
    }
}
