using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ItemInteraction : MonoBehaviour
{
    bool onPressable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Down(InputAction.CallbackContext context)
    {
        Debug.Log("Down");

        if (onPressable)
        {
            //if pressing down on an interactable object, find object name and give it to a different script to launch dialogue/cutscene/whatever

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Pressable")
        {
            onPressable = true;
            Debug.Log("Entered");
        }
    }
}
