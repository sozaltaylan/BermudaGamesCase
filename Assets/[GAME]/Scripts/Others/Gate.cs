using TMPro;
using UnityEngine;

namespace BermudaGamesCase.Others
{
    public class Gate : MonoBehaviour
    {
        #region Variables
        private TextMeshProUGUI _textMeshPro;
        private Material _defaultMaterial;


        [SerializeField] private GameObject particle;
        [SerializeField] private string bannerText;
        [SerializeField] private ItemData itemData;


        [HideInInspector] public float money;

        #endregion
        #region Methods

        private void Awake()
        {
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();   
        }
        private void Start()
        {
            money = itemData.amount;
            _textMeshPro.text = bannerText;
        }
        
        public void SetParticle()
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
        }


        #endregion
    }

}