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
    public GameObject TextMenu;
    public GameObject StatusMenu;

    public bool isText = false;

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
        StatusMenu.SetActive(true);
        if (Input.GetButtonDown(InputType.Text))
            isText = !isText;
        if (isText)
        {
            HideUI();
            TextMenu.SetActive(true);
        }
        else
        {
            TextMenu.SetActive(false);
        }
    }

    void HideUI()
    {
        EscapeMenu.SetActive(false);
        InventoryMenu.SetActive(false);
        CraftingMenu.SetActive(false);
        StatusMenu.SetActive(false);
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
        HideUI();
        if (Input.GetButtonDown(InputType.EscapeMenu))
        {
            SetStatus(UIStatus.EscapeMenu);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown(InputType.InventoryMenu))
        {
            SetStatus(UIStatus.InventoryMenu);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void InEscMenu()
    {
        EscapeMenu.SetActive(true);
        if (Input.GetButtonDown(InputType.EscapeMenu))
        {
            SetStatusToGame();
        }
    }
    void InInventory()
    {
        Player.inInventory = true;
        InventoryMenu.SetActive(true);
        if (Input.GetButtonDown(InputType.EscapeMenu) 
            || Input.GetButtonDown(InputType.InventoryMenu))
        {
            SetStatusToGame();
            Player.inInventory = false;
        }
    }
    void InCrafting()
    {
        CraftingMenu.SetActive(true);
        if (Input.GetButtonDown(InputType.EscapeMenu)
            || Input.GetButtonDown(InputType.InventoryMenu))
        {
            SetStatusToGame();
        }
    }
}
