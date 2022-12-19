using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lose : UICanvas
{
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start() {
        scoreText.text = "Best Score: " + PlayerPrefs.GetInt("COIN").ToString();
    }
    public void Restart() {
        GameController.instance.Lose();
    }
}
