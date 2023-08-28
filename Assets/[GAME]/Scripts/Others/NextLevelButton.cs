using BermudaGamesCase.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
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
        CoreGameSignals.onLoadNextScene?.Invoke();
    }
}
