using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private GameManager gm;

    public float jumpForce = 7f;
    public float forwardJumpForce = 5f;
    public float yForce = 15f;
    public float maxJumpDistance = 5f;    
    public float fallMultiplier = 5f;
    public GameObject playerFuelEffect;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gm = GameObject.FindObjectOfType<GameManager>();
        GameManager.gameOn = true;
    }

    private void FixedUpdate()
    {

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
        
        if (rb.position.y > 1   )
        {
            anim.SetBool("Jump", true);

        } else if (rb.position.y < .75)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Falling", true);
        }

        if (Input.GetMouseButton(0))
        {
            rb.velocity += transform.forward * forwardJumpForce * Time.deltaTime;
            rb.velocity += Vector3.up * yForce * Time.deltaTime;
            playerFuelEffect.SetActive(true);
            anim.SetBool("Moving", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerFuelEffect.SetActive(false);

        }

        if (rb.velocity.y > maxJumpDistance)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxJumpDistance, rb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
     
        rb.velocity = new Vector3(0, jumpForce * Time.deltaTime, 0);
        anim.SetBool("Jump", true);

        if (collision.gameObject.CompareTag("Win"))
        {
            anim.SetBool("Dance", true);
            Invoke("DisplayLevelCompleteMenu", 1f);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("Jump", false);
    }

    void DisplayLevelCompleteMenu()
    {
        gm.ShowLevelCompleteMenu();
    }
}
