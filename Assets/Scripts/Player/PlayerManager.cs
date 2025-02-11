using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InGameGUI inGameGUI;
    PlayerController playerController;
    MouseLook mouseLook;
    FreeCam freeCam;
    Camera playerCamera;

    public string playerName = "";
    public bool isInGame = false;

    private void Awake()
    {
        inGameGUI = GetComponentInChildren<InGameGUI>();
        playerController = GetComponent<PlayerController>();
        mouseLook = GetComponentInChildren<MouseLook>();
        freeCam = GetComponentInChildren<FreeCam>();
        playerCamera = transform.GetChild(0).GetComponent<Camera>();
    }

    private void Update()
    {
        if(isInGame)
        {
            playerController.enabled = false;
            inGameGUI.gameObject.SetActive(true);
        }
        else
        {
            inGameGUI.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.G))
            JoinTable();
    }

    private void JoinTable()
    {
        if(!isInGame)
        {
            isInGame = true;
            PlayerSpot currentSpot = GameManager.instance.AddPlayer(this);
            playerCamera.transform.SetParent(currentSpot.transform);
            playerCamera.transform.localPosition = Vector3.zero;
            playerCamera.transform.localRotation = Quaternion.identity;
            mouseLook.enabled = false;
            freeCam.enabled = true;
            
            GetComponent<MeshRenderer>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
