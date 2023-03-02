    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TriggerExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem explosion;
    private Collider2D[] barrels;
    [SerializeField]
    private Animator cutSceneAnimator;
    [SerializeField]
    private Transform explosionPosition;
    [SerializeField]
    private PointEffector2D pointEffector;
    [SerializeField]
    private float explosionRadius = 40.0f;
    [SerializeField]
    private float explosionMulti = 10000.0f;
    [SerializeField]
    private CinemachineVirtualCamera camera;
    [SerializeField]
    private GameObject oil_drig;
    [SerializeField]
    private GameObject scrapMetal;
    [SerializeField]
    private Animator doorAnimator;
    ParticleSystem[] particleSystems;
    private float explosionTime = 4.0f;
    private float shakeTime = 0.0f;



    private void Awake()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }
    
    private void Update()
    {
        shakeTime -= Time.deltaTime;
        if(shakeTime <= 0.0f)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0.0f;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("IceBall"))
        {
            
            Explode();
        }
    }

    public void Explode()
    {
        barrels = Physics2D.OverlapCircleAll(explosionPosition.position, explosionRadius);
        foreach(ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
        foreach(Collider2D collider in barrels)
        {
            Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
            if(rigidbody != null)
            {
                Vector2 distance = collider.transform.position - explosionPosition.position;
                if (distance.magnitude > 0)
                {
                    float force = explosionMulti / distance.magnitude;
                    rigidbody.AddForce(distance * force);

                }

            }
        }
        shakeCamera();
        Invoke(nameof(stopCutScene), explosionTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(explosionPosition.position, explosionRadius);
    }
    private void shakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 8.0f   ;
        shakeTime = 2.0f;
         

    }
    private void stopExplosion()
    {
        pointEffector.enabled = false;
    }
    private void stopCutScene()
    {
        cutSceneAnimator.SetBool("cutScene4", false);
        oil_drig.SetActive(false);
        scrapMetal.SetActive(true);
        doorAnimator.SetTrigger("openDoor");
    }
}
