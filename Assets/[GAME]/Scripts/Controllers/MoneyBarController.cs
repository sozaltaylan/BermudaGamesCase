using UnityEngine;
using UnityEngine.UI;

public class MoneyBarController : MonoBehaviour
{
    public Image moneyBar;

    [SerializeField] private float currentMoney, maxMoney;
    [SerializeField] private float startMoney;

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
    }

    private void MoneyBarFiller()
    {
        moneyBar.fillAmount = Mathf.Lerp(moneyBar.fillAmount, currentMoney / maxMoney, lerpSpeed);
    }

   private void ColorChanger()
    {
        Color moneyColor = Color.Lerp(Color.red, Color.green, (currentMoney / maxMoney));

        moneyBar.color = moneyColor;

    }
    public void SetMoney(float money)
    {
            currentMoney += money;
    }
}