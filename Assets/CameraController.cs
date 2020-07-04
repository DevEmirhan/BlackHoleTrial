using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public Camera cam;
    public CinemachineVirtualCamera cmVirtual;
    public AudioListener myListener;
    private int isSoundOn;
    //public GameObject soundOn, soundOff;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        isSoundOn = PlayerPrefs.GetInt("Sound");
        if (isSoundOn == 1)
        {
            myListener.enabled = true;
            // soundOn.SetActive(true);
            // soundOff.SetActive(false);
        }
        else
        {
            myListener.enabled = false;
            // soundOn.SetActive(false);
            // soundOff.SetActive(true);
        }
    }
    public GameObject target;
    public Vector3 offset;
    private void Update()
    {
        if (target)
        {
            //transform.position = new Vector3(target.transform.position.x,target.transform.position.y,target.transform.position.z) + offset;
            cmVirtual.LookAt = target.transform;
            cmVirtual.Follow = target.transform;
        }
    }
    public void DoFov()
    {
        CinemachineFramingTransposer transposer = cmVirtual.GetCinemachineComponent<CinemachineFramingTransposer>();
        DOTween.To(() => transposer.m_CameraDistance, x => transposer.m_CameraDistance = x, 8, 0.5f);
    }
    public void DoZoomOut()
    {
        CinemachineFramingTransposer transposer = cmVirtual.GetCinemachineComponent<CinemachineFramingTransposer>();
        DOTween.To(() => transposer.m_CameraDistance, x => transposer.m_CameraDistance = x, 10, 0.5f);
    }
    public void DoZoomIn()
    {
        CinemachineFramingTransposer transposer = cmVirtual.GetCinemachineComponent<CinemachineFramingTransposer>();
        DOTween.To(() => transposer.m_CameraDistance, x => transposer.m_CameraDistance = x, 8, 0.5f);
    }

    public void AudioListenerSwitch(bool a)
    {
        if (a)
        {
            myListener.enabled = a;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            myListener.enabled = a;
            PlayerPrefs.SetInt("Sound", 0);
        }
    }
}

