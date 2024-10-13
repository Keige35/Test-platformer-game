using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject dieScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject restartButton;
    private int finishTimeSeconds;
    private void Start()
    {
        OnEnabled();
    }

    private void OnEnabled()
    {
        EventBus.onPlayerDied += Die;
        EventBus.onPlayerWin += Win;
        EventBus.onCloseGame += CloseGame;
    }
    private void OnDisabled()
    {
        EventBus.onPlayerDied -= Die;
        EventBus.onPlayerWin -= Win;
        EventBus.onCloseGame -= CloseGame;
    }

    private void Die()
    {
        dieScreen.SetActive(true);
        restartButton.SetActive(true);
        Cursor.visible = true;
        OnDisabled();
    }
    private void Win()
    {
        winScreen.SetActive(true);
        restartButton.SetActive(true);
        OnDisabled();
        var seconds = EventBus.onFinishTime?.Invoke();
        var finishTime = winScreen.transform.Find("FinishTime");
        finishTime.GetComponent<TextMeshProUGUI>().text = "Время прохождения уровня!!!: " + seconds/60 + " минут "+ seconds%60+ " секунд";
        Cursor.visible = true;
    }

    private void CloseGame()
    {
        Application.Quit();
    }


}
