using System;
using UnityEngine;

namespace Arkanoid3D
{
    [CreateAssetMenu(fileName = "NewGlobalEvent", menuName = "Global Events/New Event")]

    public class GlobalEvent : ScriptableObject
    {
        public event Action OnPublished;

        public void Publish() => OnPublished?.Invoke();
    }
}