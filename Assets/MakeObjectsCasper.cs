using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectsCasper : MonoBehaviour
{
    private PlayerController playerController;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        
           
            if(collision.gameObject.tag == "GoodObjects")
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
            UIManager.Instance.slider1.value += playerController.valueOfStage1;
            playerController.GoodObjects.Remove(collision.gameObject);
              if(UIManager.Instance.vibrateToggle.isOn == true)
            {
                
                Handheld.Vibrate();
            }
            
                Destroy(collision.gameObject, .5f);
            }
            else if (collision.gameObject.tag == "GoodObjects2")
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
            UIManager.Instance.slider2.value += playerController.valueOfStage2;
            playerController.GoodObjects2.Remove(collision.gameObject);
            if (UIManager.Instance.vibrateToggle.isOn == true)
            {
                Handheld.Vibrate();
            }
           
            Destroy(collision.gameObject, .5f);
            }
            else if(collision.gameObject.tag == "BadObjects" && !playerController.isAnimationActive)
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
                playerController.BadObjects.Remove(collision.gameObject);
            if (UIManager.Instance.vibrateToggle.isOn == true)
            {
                Handheld.Vibrate();
            }
            Destroy(collision.gameObject, .5f);
            }
            else if(collision.gameObject.tag == "TransitionObject")
            {
                collision.gameObject.GetComponent<Collider>().isTrigger = true;
            if (UIManager.Instance.vibrateToggle.isOn == true)
            {
                Handheld.Vibrate();
            }
            Destroy(collision.gameObject, .5f);
            }
            else { return; }
            
            
            
            
       
       
    }

  
}
