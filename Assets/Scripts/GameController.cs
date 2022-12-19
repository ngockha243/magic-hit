using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : FastSingleton<GameController>
{
    [SerializeField] private int knifeCount;
    [SerializeField] private Vector2 knifeSpawnPosition;
    [SerializeField] private GameObject knifeObject;
    public int currentLevel = 1;
    public int currentCoin = 0;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CURRENT_LEVEL", 1);
        currentCoin = PlayerPrefs.GetInt("COIN", 0);
        GameUI.instance.SetInitialDisplayKnifeCount(knifeCount);
        GameUI.instance.ShowLevelText(currentLevel);
        GameUI.instance.ShowCoin(currentCoin);
        SpawnKnife();
    }
    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }
    public void OnSuccessfullKnifeHit()
    {
        if(knifeCount > 0)
        {
            SpawnKnife();
            AddCoin();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }
    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }
    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if(win)
        {
            SaveData();
            yield return new WaitForSecondsRealtime(0.3f);
            ReStartGame();
        }
        else
        {
            UIManager.instance.OpenUI<Lose>();
        }
    }
    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        currentLevel = 1;
        currentCoin = 0;
        PlayerPrefs.SetInt("CURRENT_LEVEL", 1);
        PlayerPrefs.SetInt("COIN", 0);
    }
    public void AddCoin()
    {
        currentCoin += 1;
        GameUI.instance.ShowCoin(currentCoin);
        PlayerPrefs.SetInt("COIN", currentCoin);
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("CURRENT_LEVEL", GameController.instance.currentLevel + 1);
        currentLevel += 1;
        
        AddCoin();
    }
}
