using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public PlayerControl Player;
    public GameObject EscapeMenu;
    public GameObject InventoryMenu;
    public GameObject CraftingMenu;

    public UIStatus currentStatus = UIStatus.InGame;
    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Debug.LogError("No player");
            Application.Quit();
        }
        HideUI();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStatus)
        {
            case UIStatus.InGame:
                InGame();
                break;
            case UIStatus.EscapeMenu:
                InEscMenu();
                break;
            case UIStatus.InventoryMenu:
                InInventory();
                break;
            case UIStatus.CraftingMenu:
                InCrafting();
                break;
            default:
                break;
        }
    }

    void HideUI()
    {
        EscapeMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        CraftingMenu.SetActive(false);
    }

    void SetStatus(UIStatus status)
    {
        currentStatus = status;
        Player.currentStatus = status;
    }
    public void SetStatusToGame()
    {
        SetStatus(UIStatus.InGame);
        HideUI();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    void InGame()
    {
        if (Input.GetButtonDown(InputType.EscapeMenu))
        {
            SetStatus(UIStatus.EscapeMenu);
            EscapeMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown(InputType.InventoryMenu))
        {
            SetStatus(UIStatus.InventoryMenu);
            InventoryMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void InEscMenu()
    {
        if (Input.GetButtonDown(InputType.EscapeMenu))
        {
            SetStatusToGame();
        }
    }
    void InInventory()
    {
        if (Input.GetButtonDown(InputType.EscapeMenu) 
            || Input.GetButtonDown(InputType.InventoryMenu))
        {
            SetStatusToGame();
        }
    }
    void InCrafting()
    {
        if (Input.GetButtonDown(InputType.EscapeMenu)
            || Input.GetButtonDown(InputType.InventoryMenu))
        {
            SetStatusToGame();
        }
    }
}
