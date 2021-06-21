using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAny : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetTxt();
    }
    
    public void SetTxt()
    {
        
        Text t = GetComponent<Text>();
        if (t)
        {
            string txt = t.text;
            int c = txt.Length;
            for (var i = 0; i < c-1; i++)
            {
                txt=txt.Insert(i * 2 + 1, "\n");
            }
            t.text = txt;
        }
    }
    
}
