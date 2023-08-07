using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class somersaultDetecter : MonoBehaviour
{
    [SerializeField] int somersaultNumber = 0;
    playerController playerControllerScript;
    public bool levelIsActive = false;
    [SerializeField] float currentZLocation;
    [SerializeField] float diff;
    [SerializeField] bool detecter = true;
    [SerializeField] TextMeshProUGUI somersaultCounter;
    [SerializeField] ParticleSystem somersaultEffect;
    void Start()
    {

        levelIsActive = true;
        playerControllerScript = FindObjectOfType<playerController>();

    }

    // Update is called once per frame
    void Update()
    {
        currentZLocation = transform.rotation.eulerAngles.z;
        if (currentZLocation < 182 && currentZLocation > 178 && detecter)
        {
            detecter = false;
            somersaultNumber++;
            somersaultEffect.Play();
            somersaultCounter.text = somersaultNumber.ToString();
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        detecter = true;
    }

}
