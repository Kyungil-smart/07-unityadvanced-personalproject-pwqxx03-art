using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpForce;
    public int itemCount;
    bool isjump;
    Rigidbody rigid;

    void Awake()
    {   
     
        isjump = false;
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && ! isjump)
        {
            isjump = true;
            rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isjump = false;
        }
    }
    void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Itemc"))
        {
            itemCount++;

            AudioSource audio = GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }

            other.gameObject.SetActive(false);
        }
     }
}   

