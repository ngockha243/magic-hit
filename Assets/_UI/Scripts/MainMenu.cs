using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : UICanvas
{
    private void Start() {

    }
    public void Play()
    {
        
        Close();
    }
    public void Quit()
    {
        
        Application.Quit();
    }
}
