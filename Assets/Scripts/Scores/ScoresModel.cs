using UnityEngine;

namespace Arkanoid3D
{
    public class ScoresModel
    {
        private const int MAX_REBOUNDS = int.MaxValue;
        private const int MAX_MISSES = int.MaxValue;

        public int CurrentRebounds {  get; private set; }
        public int CurrentMisses { get; private set; }

        public void AddRebounds() => CurrentRebounds = Mathf.Clamp(CurrentRebounds + 1, 0, MAX_REBOUNDS);

        public void AddMisses() => CurrentMisses = Mathf.Clamp(CurrentMisses + 1, 0, MAX_MISSES);
    }
}