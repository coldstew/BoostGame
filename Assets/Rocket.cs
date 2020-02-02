using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    private Rigidbody m_rigidBody;

    private AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision other)
    {
        print("Collided");
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var upThisFrame = mainThrust * Time.deltaTime;
            m_rigidBody.AddRelativeForce(Vector3.up * upThisFrame);
            if (!m_AudioSource.isPlaying)
                m_AudioSource.Play();
        }
        else
        {
            m_AudioSource.Stop();
        }
    }
    private void Rotate()
    {
        m_rigidBody.freezeRotation = true; // take manual control of rotation

        var rotationThisFrame = rcsThrust * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        
        m_rigidBody.freezeRotation = false;
    }
}
