using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    public float firstOccurenceTime;
    public float covidDurationTime;
    public float covidIntervalTime;
    public bool isLooping;
    public ParticleSystem covidParticle;
    public float cooldown;
    private float timer;
    void Start()
    {
        covidParticle.emissionRate = 50;
        covidParticle.enableEmission = false;
        timer = cooldown;

        if(isLooping){
            InvokeRepeating("emitCovid", firstOccurenceTime, covidIntervalTime);
            InvokeRepeating("stopCovid", firstOccurenceTime + covidDurationTime, covidIntervalTime);
        }
        else{
            Invoke("emitCovid", firstOccurenceTime);
            Invoke("stopCovid", firstOccurenceTime + covidDurationTime);
        }

    }
    void FixedUpdate(){
        timer -= Time.deltaTime;
    }
    public void emitCovid(){
        covidParticle.enableEmission = true;
    }
    public void stopCovid(){
         covidParticle.enableEmission = false;
    }

       void OnParticleCollision(GameObject other)
    {
        if(timer <= 0){
            if(other.tag == "Player"){
                other.GetComponent<Health>().DoDamage();
                timer = cooldown;
            }
        }
    }
}
