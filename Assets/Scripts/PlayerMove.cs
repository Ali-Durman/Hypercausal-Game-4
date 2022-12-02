using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public bool isMoving;
    public Animator anim;
    public static PlayerMove Instance;
    public Rigidbody rb;
    public bool PlayerIsOnTheGround = true;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isMoving) return;
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && PlayerIsOnTheGround)
        {
            anim.SetTrigger("jump");
            rb.AddForce(new Vector3(0, 5, 3.1f), ForceMode.Impulse);
            PlayerIsOnTheGround = false;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            PlayerIsOnTheGround = true;
        }
    }
}
