using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    bool open; 
    bool close;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(open == true){
            close = false;
        }
        if(close == true){
            close = false;
        }
    }

    private void DoorMovement()
    {
        if(open == true)
        {
            anim.SetBool("Open", true);
        }
        else
        {
            anim.SetBool("Close", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            open = true;
            DoorMovement();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            open = false;
            close = true;
            DoorMovement();
        }
    }
}
