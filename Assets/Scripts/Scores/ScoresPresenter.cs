using UnityEngine;

namespace Arkanoid3D
{
    public class ScoresPresenter : MonoBehaviour
    {
        [SerializeField] private ScoresView _view;

        private ScoresModel _model;

        private void Awake() => _model = new ScoresModel();

        public void UpdateReboundsCount()
        {
            _model.AddRebounds();
            _view.DisplayRebounds(_model.CurrentRebounds);
        }

        public void UpdateMissesCount()
        {
            _model.AddMisses();
            _view.DisplayMisses(_model.CurrentMisses);
        }
    }
}