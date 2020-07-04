using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectsCasper : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
           
            if(collision.gameObject.tag == "GoodObjects")
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
                PlayerController.Instance.GoodObjects.Remove(collision.gameObject);
                Destroy(collision.gameObject, .5f);
            }
            else if (collision.gameObject.tag == "GoodObjects2")
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
                PlayerController.Instance.GoodObjects2.Remove(collision.gameObject);
                Destroy(collision.gameObject, .5f);
            }
            else if(collision.gameObject.tag == "BadObjects" && !PlayerController.Instance.isAnimationActive)
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
                PlayerController.Instance.BadObjects.Remove(collision.gameObject);
                Destroy(collision.gameObject, .5f);
            }
            else if(collision.gameObject.tag == "TransitionObject")
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(collision.gameObject, .5f);
            }
            else { return; }
            
            
            
            
       
       
    }

  
}
