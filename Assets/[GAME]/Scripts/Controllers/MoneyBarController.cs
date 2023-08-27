using BermudaGamesCase.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBarController : MonoBehaviour
{
    public Image moneyBar;

    [SerializeField] private float currentMoney, maxMoney;
    [SerializeField] private float startMoney;

    [SerializeField] private TextMeshProUGUI statuText;

    float lerpSpeed;

    #region Properties

    public float CurrentMoney => currentMoney;
    #endregion
    private void Start()
    {
        currentMoney = startMoney;
    }

    private void Update()
    {

        lerpSpeed = 3f * Time.deltaTime;

        MoneyBarFiller();
        ColorChanger();
        SwithcStatu();
    }

    private void MoneyBarFiller()
    {
        moneyBar.fillAmount = Mathf.Lerp(moneyBar.fillAmount, currentMoney / maxMoney, lerpSpeed);
    }

   private void ColorChanger()
    {
        Color moneyColor = Color.Lerp(Color.red, Color.green, (currentMoney / maxMoney));

        moneyBar.color = moneyColor;
        statuText.color = moneyColor;

    }
    private void SwithcStatu()
    {
        if (currentMoney <= 33)
        {
            statuText.text = PlayerType.POOR.ToString();
        }
        else if (currentMoney >= 34 && currentMoney < 66)
        {
            statuText.text = PlayerType.AVERAGE.ToString();
        }
        else if (currentMoney >= 66)
        {
            statuText.text = PlayerType.RICH.ToString();
        }
    }
    public void SetMoney(float money)
    {
            currentMoney += money;
    }
}