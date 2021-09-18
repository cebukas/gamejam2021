using UnityEngine;

public class Covid : MonoBehaviour
{
    [SerializeField]
    private float firstOccurenceTime;
    [SerializeField]
    private float covidDurationTime;
    [SerializeField]
    private float covidIntervalTime;
    [SerializeField]
    private bool isLooping;
    [SerializeField]
    private ParticleSystem covidParticle;
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private GameObject player;
    
    private float _timer;
    
    void Start()
    {
        var emission = covidParticle.emission;
        emission.rateOverTime = 50;
        emission.enabled = false;
        _timer = cooldown;

        if(isLooping){
            InvokeRepeating(nameof(EmitCovid), firstOccurenceTime, covidIntervalTime);
            InvokeRepeating(nameof(StopCovid), firstOccurenceTime + covidDurationTime, covidIntervalTime);
        }
        else{
            Invoke(nameof(EmitCovid), firstOccurenceTime);
            Invoke(nameof(StopCovid), firstOccurenceTime + covidDurationTime);
        }

    }
    void FixedUpdate()
    {
        _timer -= Time.deltaTime;
    }

    public void EmitCovid()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, this.transform.position) <= 5f){
            GetComponent<AudioSource>().Play();
        }
        var emission = covidParticle.emission;
        emission.enabled = true;
    }

    public void StopCovid()
    {
        var emission = covidParticle.emission;
        emission.enabled = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!(_timer <= 0)) return;
        if (!other.CompareTag("Player")) return; //TODO (Lukas): TAG_PLAYER
        other.GetComponent<Health>().DoDamage();
        _timer = cooldown;
    }
}
