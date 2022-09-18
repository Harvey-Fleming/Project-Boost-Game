using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 150f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem MainboosterParticles;
    [SerializeField] ParticleSystem LeftboosterParticles;
    [SerializeField] ParticleSystem RightboosterParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust();
       ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            StartThrust();
        }
        else 
            {
                Stopthrust();
            }
    }

    void StartThrust()
    {
        if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
           
           if (!MainboosterParticles.isPlaying)
           {
                MainboosterParticles.Play();
           }
    }
    
    void Stopthrust()
    {
        audioSource.Stop();
        MainboosterParticles.Stop();
    }

    void ProcessRotation()
    {
        
        if (Input.GetKey(KeyCode.A)) 
        {
            StartLeftThrust();
        }

        else if (Input.GetKey(KeyCode.D)) 
        {
            StartRightThrust();
        }
        else 
        {
            StopRotationParticles();
        }


    }

    void StartRightThrust()
    {
        ApplyRotation(-rotateThrust);
            if (!LeftboosterParticles.isPlaying)
           {
                LeftboosterParticles.Play();
           }   
    }

    void StartLeftThrust()
    {
        ApplyRotation(rotateThrust);
            if (!RightboosterParticles.isPlaying)
           {
                RightboosterParticles.Play();
           } 
    }

    void StopRotationParticles()
    {
        LeftboosterParticles.Stop();
        RightboosterParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame) 
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation


    }

}
