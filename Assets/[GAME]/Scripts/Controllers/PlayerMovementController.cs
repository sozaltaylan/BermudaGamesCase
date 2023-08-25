using UnityEngine;

namespace BermudaGamesCase.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerData playerData;

        private float _speed;
        private float _rotationSpeed;


        #endregion

        #region Methods
        private void Start()
        {
            _speed = playerData.Speed;
            _speed = playerData.RotationSpeed;
        }

        private void Update()
        {
            
        }
        private void Movement()
        {

        }

        #endregion
    }
}
