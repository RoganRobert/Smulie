using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the size of the ‘Boundary’ depending on Viewport. When objects go beyond the ‘Boundary’, they are destroyed or deactivated.
/// </summary>
public class Boundary : MonoBehaviour {

    //when another object leaves collider
    private void OnTriggerExit2D(Collider2D collision) 
    {        
        if (collision.tag == "Point")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Missile") 
            Destroy(collision.gameObject);

    }

}
