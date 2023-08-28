using BermudaGamesCase.Managers;
using BermudaGamesCase.Signals;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlayButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(HandleButtonClicked);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleButtonClicked);
    }

    private void HandleButtonClicked()
    {
        CoreGameSignals.onGameStart?.Invoke();
        CoreGameSignals.onInputToggle?.Invoke(true);
        button.gameObject.SetActive(false);
    }

}
