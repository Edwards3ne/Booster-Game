using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationSpeed = 100f;
    AudioSource audioSource;

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
        float thrustUp = mainThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            
            rb.AddRelativeForce(Vector3.up*thrustUp);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            

            
        }
        else
        {
            audioSource.Stop();
        }


    }

    void ProcessRotation()
    {


        if (Input.GetKey(KeyCode.A))
        {
            Rotation(rotationSpeed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotation(-rotationSpeed);
        }

        void Rotation(float rotationThisFrame)
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }

}
