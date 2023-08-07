using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class diamondMovement : MonoBehaviour
{
    bool up = true;
    [SerializeField] public GameObject diamond;
    public TextMeshProUGUI collectedDiamondsText;
    ParticleSystem ps;
    SpriteRenderer sr;
    [SerializeField] AudioSource audiosource;
    void Start(){
        StartCoroutine(movement());
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(up == true){
            transform.Translate(0,2*Time.deltaTime,0);
        }else{
            transform.Translate(0,-2*Time.deltaTime,0);
        }

    }
    IEnumerator movement(){
        while(true){
            yield return new WaitForSeconds(0.3f);
            up = !up;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "fullcollider"){
            ps.Play();
            audiosource.Play();
            sr.enabled = false;
            playerController.collectedDiamonds ++;
            collectedDiamondsText.text = playerController.collectedDiamonds.ToString();
        }
    }
}
