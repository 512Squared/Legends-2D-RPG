using System;
using UnityEngine;

namespace DOTweenConfigs
{
    [Serializable]
    public class SnapShake3DTweenConfig : Shake3DTweenConfig
    {
        [SerializeField]
        private bool m_snapping = false;

        public bool Snapping
        {
            get { return m_snapping; }
        }
    }
}
