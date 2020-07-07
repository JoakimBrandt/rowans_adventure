using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text gemText;
    public TMP_Text cherryText;

    public void updateGemText(string text)
    {
        gemText.text = text;
    }

    public void updateCherryText(string text)
    {
        cherryText.text = text;
    }

}
