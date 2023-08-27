using BermudaGamesCase.Exceptions;
using UnityEngine;
using UnityEngine.Events;

namespace BermudaGamesCase.Signals
{
    public static class CoreGameSignals 
    {
        public static UnityAction onGameStart;
        public static UnityAction<float> onChangeCameraTargetPosition;
        public static UnityAction<bool> onInputToggle;
        public static UnityAction<float> onChangeTotalMoney;
        public static UnityAction UpgradeTotalMoneyUI;
    }
}

