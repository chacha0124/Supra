using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    RaycastHit hit;
    public XRController rightcontroller = null;
    public XRController leftcontroller = null;
    public InventorySocket inventorySocket;
    ControlStationPuzzleSocket socketRotation;
    ControlStationPuzzleButton puzzleButton;
    HandScanner handScanner;
    public Device curDevice;
    public float coolTime = 0.5f;
    public bool isInteracting = false;

    public bool activateMainMenu;

    public AudioSource _audio;
    public AudioClip _grapSound;
    public AudioClip _rotateSound;

    private void Update()
    {
        if (leftcontroller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            if (position.x != 0 && position.y != 0)
            {
                EventManager.Instance.Move();
            }
        }

        if (rightcontroller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position2))
        {
            if (position2.x != 0 && position2.y != 0)
            {
                EventManager.Instance.ChangeSight();
            }
        }

        if (rightcontroller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool AButton))
        {
            if (AButton && !isInteracting && TutorialImageManager.Instance._onImage)
            {
                isInteracting = !isInteracting;
                TutorialImageManager.Instance._onImage = false;
                TutorialImageManager.Instance._imageCanvas.SetActive(false);
                Invoke("canInteracting", coolTime);
            }
            
            if (AButton && !isInteracting && Physics.Raycast(rightcontroller.transform.position, rightcontroller.transform.forward, out hit, 8))
            {
                if (hit.collider.CompareTag("ControlStationPuzzlePiece"))
                {
                    isInteracting = !isInteracting;
                    socketRotation = hit.transform.gameObject.GetComponent<ControlStationPuzzleSocket>();
                    socketRotation.Rotation();
                    RotateSoundPlay();
                    Invoke("canInteracting", coolTime);
                }
                else if (hit.collider.CompareTag("ControlStationPuzzleButton"))
                {
                    isInteracting = !isInteracting;
                    puzzleButton = hit.transform.gameObject.GetComponent<ControlStationPuzzleButton>();
                    puzzleButton._ButtonClick();
                    Invoke("canInteracting", coolTime);
                }
                else if (hit.collider.CompareTag("HandScanner"))
                {
                    Debug.Log("HandScanner");
                    isInteracting = !isInteracting;
                    Invoke("canInteracting", coolTime);
                    handScanner = hit.transform.gameObject.GetComponent<HandScanner>();
                    handScanner.DoorOpen();
                }
                else if (hit.collider.CompareTag("Device"))
                {
                    isInteracting = !isInteracting;
                    curDevice = hit.transform.gameObject.GetComponent<Device>();
                    if (curDevice.rootDevice.CompareTag("Device"))
                    {
                        curDevice.rootDevice.transform.Rotate(new Vector3(0, 90f, 0));
                    }
                    else if (curDevice.rootDevice.CompareTag("Floor"))
                    {
                        curDevice.rootDevice.transform.Rotate(new Vector3(0, 0, 90f));
                    }
                    RotateSoundPlay();
                    Invoke("canInteracting", coolTime);
                }
                else if (hit.collider.CompareTag("Floor"))
                {
                    isInteracting = !isInteracting;
                    hit.transform.Rotate(new Vector3(0, 0, 90f));
                    RotateSoundPlay();
                    Invoke("canInteracting", coolTime);
                }
            }
        }
        if (rightcontroller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool BButton))
        {
            if (BButton && !isInteracting)
            {
                isInteracting = !isInteracting;

                activateMainMenu = !activateMainMenu;
                if (activateMainMenu)
                {
                    UIManager.Instance.InGameMenuactivate();
                }
                else
                {
                    UIManager.Instance.InGameExitButton();
                }

                Invoke("canInteracting", coolTime);
            }
        }
        if (leftcontroller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool XButton))
        {
            if (XButton && !isInteracting)
            {
                isInteracting = !isInteracting;
                inventorySocket.GetComponent<InventorySocket>().PrevSlot();
                Invoke("canInteracting", coolTime);
            }
        }
        if (leftcontroller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool YButton))
        {
            if (YButton && !isInteracting)
            {
                isInteracting = !isInteracting;
                inventorySocket.GetComponent<InventorySocket>().NextSlot();
                Invoke("canInteracting", coolTime);
            }
        }
    }
    private void canInteracting ()
    {
        isInteracting = !isInteracting;
    }

    public void GrapSoundPlay()
    {
        _audio.clip = _grapSound;
        _audio.Play();
    }

    public void RotateSoundPlay()
    {
        _audio.clip = _rotateSound;
        _audio.Play();
    }
}
