using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : FastSingleton<GameUI>
{
    [SerializeField] private GameObject panelKnives;
    [SerializeField] private GameObject iconKnife;
    [SerializeField] private Color useKnifeIconColor;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinText;
    public void SetInitialDisplayKnifeCount(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(iconKnife, panelKnives.transform);
        }
    }

    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange++).GetComponent<Image>().color = useKnifeIconColor;
    }
    public void ShowReStartButton()
    {

    }
    public void ShowLevelText(int level)
    {
        levelText.text = "Level " + level.ToString();
    }
    public void ShowCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
}
