using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using System.Security.Cryptography;

public class PlayerController : Singleton<PlayerController>
{
    public float speed;
    private Joystick joystick;
    public bool isInputGet;
    public Animator gfxAnimator;
    public GameObject walkIndicator;
    private int checkBadObject;
    public Camera mainCamera;
    public bool FirstStage = true;
    public bool isAnimationActive = false;
    public GameObject StageGate;
    public ParticleSystem Confetti;
    

    [Header("Level Objects")][Space(5)]
    public List<GameObject> GoodObjects;
    public List<GameObject> GoodObjects2;
    public List<GameObject> BadObjects;

    
    
    void Start()
    {
        isInputGet = true;
        joystick = GameManager.Instance.joystick;
        checkBadObject = BadObjects.Count;

    }
    void Update()

    {
        
        if (isInputGet)
        {
            
            if (joystick.Direction.magnitude >= .75f)
            {
                
                transform.forward = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
                walkIndicator.transform.position = new Vector3(transform.position.x + joystick.Direction.x, walkIndicator.transform.position.y, transform.position.z + joystick.Direction.y);
                transform.position = transform.position + transform.forward * Time.deltaTime * speed;

            }
            else
            {
               
                walkIndicator.transform.position = new Vector3(transform.position.x, walkIndicator.transform.position.y, transform.position.z);
            }
            


            if (FirstStage)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), transform.position.y, Mathf.Clamp(transform.position.z, -2f, 16f));
            }
            else
            {
                Debug.Log("Here Is the second stage!");
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), transform.position.y, Mathf.Clamp(transform.position.z, 38f, 56f));
                
            }
        }


        if (isAnimationActive)
        {
            isInputGet = false;
        }



        if (GoodObjects.Count == 0 && FirstStage)
        {
            isAnimationActive = true;
            transform.DOLocalMoveX( 0f , 2f, false).OnComplete(MoveToNextStage).SetId("tween1");
            StageGate.transform.DOLocalMoveY(-.6f, 2f, false).SetId("tween2");
          
            
            Debug.Log("You can pass the Stage2");
            
           
           
           
        }
        if (GoodObjects2.Count == 0)
        {
            isInputGet = false;
            if(GameManager.Instance.gameState != GameState.Win)
            {
                Confetti.Play();
            }
           
            GameManager.Instance.Win();
            Debug.Log("You handeled to first phase");
        }

        if (BadObjects.Count < checkBadObject)
        {
            isInputGet = false;
            if (GameManager.Instance.gameState != GameState.Lose)
            {
                mainCamera.DOShakePosition(.75f, .5f, 10, 90, true);
            }
            
            GameManager.Instance.Lose();
            Debug.Log("You lost the game");
        }

     
    }
    public void MoveToNextStage()
    {
        
        
        mainCamera.transform.DOMoveZ(32f, 4f).SetEase(Ease.Linear);
        
        transform.DOMoveZ(39f, 4f).OnComplete(NextStage).SetId("Badoom");
    }
    public void NextStage()
    {
        DOTween.Kill("tween1", false);
        DOTween.Kill("tween2", false);
        DOTween.Kill("Badoom", false);
        FirstStage = false;
       
        isAnimationActive = false;
        isInputGet = true;
        
      
        
    }

}
      

