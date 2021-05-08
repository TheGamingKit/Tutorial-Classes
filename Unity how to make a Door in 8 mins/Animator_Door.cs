using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]//Prevents the Removal of the animator or automatically Adds an Animator if one is not there.
public class Animator_Door : MonoBehaviour
{
    private Animator animator;
    [SerializeField]string str_OpenDoorAnimation = "";//holds the names of the Animation to feed to the Animator
    [SerializeField]string str_CloseDoorAnimation = "";
    private bool bool_DoorIsOpen = false;//holds the state of the door
    private bool bool_DoorSelectable = false;//is the player near the door
    void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();//get the reference to the animator on this gameObject
    }
    void OnTriggerEnter(Collider collider)
    {//checks if the player is in the radius of the door
        if (collider.gameObject.tag == "Player") bool_DoorSelectable = true;
    }
    void OnTriggerExit(Collider collider)
    {//check if the player is leaving the radius of the door
        if (collider.gameObject.tag == "Player") bool_DoorSelectable = false;
    }

    void Update()
    {
        if (bool_DoorSelectable && Input.GetKeyDown(KeyCode.E)) 
        {//if the player is within the doors radius and pushes 'E'
            if(!bool_DoorIsOpen) method_OpenDoor_void();//if the door is open, close it
            else if( bool_DoorIsOpen) method_CloseDoor_void();//else if the door is closed Open it
        }
    }

    public void method_OpenDoor_void()
    {
        
        bool_DoorIsOpen = true;//record the state of the door as 'Open'
        animator.Play(str_OpenDoorAnimation, 0);//play the open door animation, on animation layer 0
    }

    public void method_CloseDoor_void()
    {
        bool_DoorIsOpen = false;//record the state of the door as 'Closed'
        animator.Play(str_CloseDoorAnimation, 0);//play the door close animation, on animation layer 0
    }
}