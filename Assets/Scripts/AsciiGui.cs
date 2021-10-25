using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AsciiGui : MonoBehaviour
{
    public Vector2 displaySize = new Vector2(100, 100);
    private string[] displayImage;
    public Text displayTextObject;

    public int curHp = 37;
    public int maxHp = 236;

    public int curMp = 21;
    public int maxMP = 55;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrepareDisplay();
        StatusDisplay();
        Draw();
    }
    void PrepareDisplay()
    {
        displayImage = new string[(int)displaySize.y];
        for (int i = 0; i < (int)displaySize.y; i++)
        {
            for (int j = 0; j < (int)displaySize.x; j++)
            {
                displayImage[i] += " ";
            }
        }
    }

    void StatusDisplay()
    {
        string hp;
        string mp;

        int stringSize = 21;
        
        string[] image = new string[] {
            "     ---------------------",
            " HP:                      ",
            "     ---------------------",
            " MP:                      ",
            "     ---------------------"
        };
        
        for (int i = 0; i < image.Length; i++)
        {
            Replace(0, ref displayImage[i], image[i]);
        }

        hp = CreateBar((float)curHp, (float)maxHp, stringSize, "|");
        mp = CreateBar((float)curMp, (float)maxMP, stringSize, "|");
        Replace(5, ref displayImage[1], hp);
        Replace(5, ref displayImage[3], mp);


        hp = curHp + "/" + maxHp;
        mp = curMp + "/" + maxMP;
        Replace(15 - curHp.ToString().Length, ref displayImage[1], hp);
        Replace(15 - curMp.ToString().Length, ref displayImage[3], mp);
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

    void Draw()
    {
        //Debug.Log(string.Join("\n", displayImage));
        displayTextObject.text = string.Join("\n", displayImage);
    }
}
