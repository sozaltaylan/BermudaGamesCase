using UnityEngine;
using UnityEngine.UI;

public class MoneyBarController : MonoBehaviour
{
    public Image moneyBar;

    [SerializeField] private float money, maxMoney;
    [SerializeField] private float startMoney;

    float lerpSpeed;

    private void Start()
    {
        money = startMoney;
    }

    private void Update()
    {

        lerpSpeed = 3f * Time.deltaTime;

        MoneyBarFiller();
        ColorChanger();
    }

    private void MoneyBarFiller()
    {
        moneyBar.fillAmount = Mathf.Lerp(moneyBar.fillAmount, money / maxMoney, lerpSpeed);
    }

   private void ColorChanger()
    {
        Color moneyColor = Color.Lerp(Color.red, Color.green, (money / maxMoney));

        moneyBar.color = moneyColor;

    }

    public void Damage(float damagePoints)
    {
        if (money > 0)
            money -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (money < maxMoney)
            money += healingPoints;

    }
}