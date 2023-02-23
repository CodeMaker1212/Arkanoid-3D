using TMPro;
using UnityEngine;

namespace Arkanoid3D
{
    public class ScoresView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _reboundsUI;
        [SerializeField] private TextMeshProUGUI _missesUI;

        public void DisplayRebounds(int currentValue) => _reboundsUI.text = $"Rebounds: {currentValue}";

        public void DisplayMisses(int currentValue) => _missesUI.text = $"Misses: {currentValue}";
    }
}