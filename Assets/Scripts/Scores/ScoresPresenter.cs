using UnityEngine;

namespace Arkanoid3D
{
    public class ScoresPresenter : MonoBehaviour
    {
        [SerializeField] private ScoresView _view;
        [SerializeField] private GlobalEvent _onRearPanelCollision;
        [SerializeField] private GlobalEvent _onBatCollision;

        private ScoresModel _model;

        private void Awake() => _model = new ScoresModel();

        private void OnEnable()
        {
            _onRearPanelCollision.OnPublished += UpdateMissesCount;
            _onBatCollision.OnPublished += UpdateReboundsCount;
        }

        private void OnDisable()
        {
            _onRearPanelCollision.OnPublished -= UpdateMissesCount;
            _onBatCollision.OnPublished -= UpdateReboundsCount;
        }

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