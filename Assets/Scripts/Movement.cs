using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainTruster;
    [SerializeField] ParticleSystem rightThuster;
    [SerializeField] ParticleSystem leftThuster;
    
    Rigidbody rb;
    AudioSource AudioSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        AudioSound = GetComponent<AudioSource>();
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
            if(!mainTruster.isPlaying)
            {
                mainTruster.Play();
            }   
            if(!AudioSound.isPlaying)
            {
                AudioSound.PlayOneShot(mainEngine);
            }
           
            rb.AddRelativeForce(UnityEngine.Vector3.up * mainThrust * Time.deltaTime);
        }
         else
            {
                AudioSound.Stop();
                mainTruster.Stop();
            }
    }
    void ProcessRotation()
    {
         if (Input.GetKey(KeyCode.A))
        {
             if(!leftThuster.isPlaying)
            {
                leftThuster.Play();
            }   
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
             if(!rightThuster.isPlaying)
            {
                rightThuster.Play();
            }   
            ApplyRotation(-rotationThrust);
            
        }
        else
            {
                rightThuster.Stop();
                leftThuster.Stop();
            }
        void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; 
        transform.Rotate(UnityEngine.Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    }
    }

