using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AsciiGui : MonoBehaviour
{
    public Vector2 displaySize = new Vector2(100, 100);
    public Vector2 listPosition = new Vector2(15, 7);
    public Vector2 listLenght = new Vector2(60, 8);

    public PlayerControl Player;

    public int listCursor = 0;

    private string[] displayImage;
    public Text displayTextObject;

    public int CurrentHealth = 37;
    public int MaxHealth = 236;

    public int CurrentStamina = 21;
    public int MaxStamina = 55;

    public List<Item> inventory = new List<Item>();

    public Vector2 characterSize = new Vector2(6, 11);

    // Start is called before the first frame update
    void Start()
    {
        //inventory.Add(new Item("T", "Good One"));
        //inventory.Add(new Item("A", "Good One"));
        //inventory.Add(new Item("KAS", "Good One"));
        
    }

    // Update is called once per frame
    void Update()
    {
        PrepareDisplay();

        if (Player.IsInventoryOpen())
        {
            inventory = Player.GetInventory();
            listCursor = Player.GetInventoryCursor();
            ShowInventoryList();
        }

        GetStatus();
        StatusDisplay();

        Draw();
    }
    void PrepareDisplay()
    {
        //displaySize = new Vector2(Screen.width / characterSize.x, Screen.height / characterSize.y);
        displayImage = new string[(int)displaySize.y];
        for (int i = 0; i < (int)displaySize.y; i++)
        {
            for (int j = 0; j < (int)displaySize.x; j++)
            {
                displayImage[i] += " ";
            }
        }
    }

    void GetStatus()
    {
        CurrentHealth = (int)Player.GetHealth();
        MaxHealth = (int)Player.GetMaxHealth();

        CurrentStamina = (int)Player.GetStamina();
        MaxStamina = (int)Player.GetMaxStamina();
    }

    void ShowInventoryList()
    {
        listLenght.x = displaySize.x - listPosition.x * 2 - 5;
        listLenght.y = (displaySize.y - listPosition.y * 2) / 4 + 1;

        CreateInventoryList();

        for (int i = 0; i < inventory.Count; i++)
        {
            Replace((int)listPosition.x + 5 + (int)(listLenght.x - inventory[i].GetName().Length) / 2, 
                ref displayImage[i * 4 + (int)listPosition.y + 2], 
                inventory[i].GetName());
            Replace((int)listPosition.x + 2,
                ref displayImage[i * 4 + (int)listPosition.y + 2],
                "00");
            Replace((int)listPosition.x + 4 - inventory[i].GetActualStackSize().ToString().Length,
                ref displayImage[i * 4 + (int)listPosition.y + 2],
                inventory[i].GetActualStackSize().ToString());
        }
    }

    void CreateInventoryList()
    {

        string[] image = CreateRow(6, (int)listLenght.x, 5, "-", "|", " ", " ");
        string[] selectedImage = CreateRow(6, (int)listLenght.x, 5, "/", "/", " ", "+");

        for (int i = 0; i < (int)listLenght.y; i++)
        {
            for (int j = 0; j < image.Length - 1; j++)
            {
                if (i == listCursor)
                    Replace((int)listPosition.x, ref displayImage[j + i * (image.Length - 1) + (int)listPosition.y], selectedImage[j]);
                else if (i == listCursor + 1 && j == 0)
                    Replace((int)listPosition.x, ref displayImage[j + i * (image.Length - 1) + (int)listPosition.y], selectedImage[j]);
                else
                    Replace((int)listPosition.x, ref displayImage[j + i * (image.Length - 1) + (int)listPosition.y], image[j]);
            }
        }
        if (listCursor + 1 == (int)listLenght.y)
            Replace((int)listPosition.x, 
                ref displayImage[(int)listLenght.y * (selectedImage.Length - 1) + (int)listPosition.y], 
                selectedImage[selectedImage.Length - 1]);
        else
            Replace((int)listPosition.x, 
                ref displayImage[(int)listLenght.y * (image.Length - 1) + (int)listPosition.y], 
                image[image.Length - 1]);
    }

    string[] CreateRow(int lenght1, int lenght2, int height, string characterTopBot, string characterLeftRight, string characterFill, string characterCorners)
    {
        string[] image = new string[height];

        image[0] += characterCorners;
        image[1] += characterLeftRight;
        image[2] += characterLeftRight;
        image[3] += characterLeftRight;
        image[4] += characterCorners;

        AddAmount(ref image[0], lenght1 - 2, characterTopBot);
        AddAmount(ref image[1], lenght1 - 2, characterFill);
        AddAmount(ref image[2], lenght1 - 2, characterFill);
        AddAmount(ref image[3], lenght1 - 2, characterFill);
        AddAmount(ref image[4], lenght1 - 2, characterTopBot);

        image[0] += characterCorners;
        image[1] += characterLeftRight;
        image[2] += characterLeftRight;
        image[3] += characterLeftRight;
        image[4] += characterCorners;

        AddAmount(ref image[0], lenght2 - 2, characterTopBot);
        AddAmount(ref image[1], lenght2 - 2, characterFill);
        AddAmount(ref image[2], lenght2 - 2, characterFill);
        AddAmount(ref image[3], lenght2 - 2, characterFill);
        AddAmount(ref image[4], lenght2 - 2, characterTopBot);

        image[0] += characterCorners;
        image[1] += characterLeftRight;
        image[2] += characterLeftRight;
        image[3] += characterLeftRight;
        image[4] += characterCorners;

        return image;
    }

    void StatusDisplay()
    {
        string hp;
        string sp;

        int stringSize = 21;
        
        string[] image = new string[] {
            "     ---------------------",
            " HP:                      ",
            "     ---------------------",
            " SP:                      ",
            "     ---------------------"
        };
        
        for (int i = 0; i < image.Length; i++)
        {
            Replace(0, ref displayImage[i], image[i]);
        }

        hp = CreateBar((float)CurrentHealth, (float)MaxHealth, stringSize, "|");
        sp = CreateBar((float)CurrentStamina, (float)MaxStamina, stringSize, "|");
        Replace(5, ref displayImage[1], hp);
        Replace(5, ref displayImage[3], sp);


        hp = CurrentHealth + "/" + MaxHealth;
        sp = CurrentStamina + "/" + MaxStamina;
        Replace(15 - CurrentHealth.ToString().Length, ref displayImage[1], hp);
        Replace(15 - CurrentStamina.ToString().Length, ref displayImage[3], sp);
    }

    string CreateBar(float currentValue, float maxValue, int stringSize, string character)
    {
        string bar = "";
        for (int i = 0; i < Mathf.Ceil(Mathf.Min((float)currentValue / maxValue, 1f) * stringSize); i++)
        {
            bar += character;
        }
        return bar;
    }

    void Replace(int position, ref string orginalText, string replaceText)
    {
        var stringBuilder = new StringBuilder(orginalText);
        stringBuilder.Remove(position, replaceText.Length).Insert(position, replaceText);
        orginalText = stringBuilder.ToString();
    }

    void AddAmount(ref string text, int amount, string character)
    {
        for (int i = 0; i < amount; i++)
        {
            text += character;
        }
    }

    void Draw()
    {
        //Debug.Log(string.Join("\n", displayImage));
        displayTextObject.text = string.Join("\n", displayImage);
    }
}
