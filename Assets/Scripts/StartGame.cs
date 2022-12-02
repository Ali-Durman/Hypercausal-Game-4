using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Animator anim;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerMove.Instance.isMoving = true;
            this.enabled = false;
            anim.SetTrigger("start");
        }
    }
}
