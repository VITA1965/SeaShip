using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public enum ShipWeapons
    {
        None,
        Cannon,
        BigCannon
    }

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] GameObject[] _cannons;

  

    float currentSpeed;

    [SerializeField] Rigidbody rb;
    Vector3 direction;

    [SerializeField] float shiftSpeed = 10f;

    int health;

    float stamina = 5f;

    [SerializeField] AudioSource characterSounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }
    public void ChangeHealth(int count)
    {
        health -= count;
        if (health <= 0)
        {
            this.enabled = false;
        }
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (direction.x != 0 || direction.z != 0)
        {
            //if (!characterSounds.isPlaying)
            //{
            //    characterSounds.Play();
            //}
        }
        if (direction.x == 0 && direction.z == 0)
        {
            //characterSounds.Stop();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            currentSpeed = movementSpeed;
        }
        if (stamina > 5f)
        {
            stamina = 5f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }

    }
    public void ChooseWeapon(ShipWeapons weapons)
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
