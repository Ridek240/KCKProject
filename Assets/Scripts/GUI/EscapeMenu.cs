using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public GUIManager GUIManager;

    public GameObject Main;
    public GameObject Settings;

    public Text Resolution;

    List<Vector2Int> possibleResolutions = new List<Vector2Int>
    {
        new Vector2Int(640, 360),
        new Vector2Int(1280, 720),
        new Vector2Int(1536, 864),
        new Vector2Int(1600, 900),
        new Vector2Int(1920, 1080),
        new Vector2Int(2048, 1152),
        new Vector2Int(2560, 1440),
        new Vector2Int(3840, 2160)
    };

    List<FullScreenMode> possibleFullscreen = new List<FullScreenMode>
    {
        FullScreenMode.ExclusiveFullScreen,
        FullScreenMode.FullScreenWindow,
        FullScreenMode.MaximizedWindow,
        FullScreenMode.Windowed
    };

    private int chosenResolution = 4;
    private int chosenFullscreen = 3;

    void Start()
    {
        SetResolution(possibleResolutions[chosenResolution]);
        SetFullscreen(possibleFullscreen[chosenFullscreen]);
    }

    void Update()
    {

    }

    public void Open()
    {
        ExitSettings();
    }

    public void ChangeRes()
    {
        chosenResolution = (chosenResolution + 1) % possibleResolutions.Count;
        SetResolution(possibleResolutions[chosenResolution]);
    }

    public void ChangeFullscreen()
    {
        chosenFullscreen = (chosenFullscreen + 1) % possibleFullscreen.Count;
        SetFullscreen(possibleFullscreen[chosenFullscreen]);
    }

    public void SetFullscreen(FullScreenMode fullScreenMode)
    {
        Screen.fullScreenMode = fullScreenMode;
    }

    public void SetResolution(Vector2Int size)
    {
        Screen.SetResolution(size.x, size.y, Screen.fullScreen);
        Resolution.text = "Resolution: "
            + possibleResolutions[chosenResolution].x
            + " / "
            + possibleResolutions[chosenResolution].y;
    }

    public void EnterSettings()
    {
        Main.SetActive(false);
        Settings.SetActive(true);
    }
    public void ExitSettings()
    {
        Settings.SetActive(false);
        Main.SetActive(true);
    }

    public void ExitMenu()
    {
        GUIManager.SetStatusToGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
