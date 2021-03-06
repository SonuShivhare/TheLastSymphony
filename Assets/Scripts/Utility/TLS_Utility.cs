using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLastSymphony
{
    public class TLS_Utility
    {
        [System.Serializable]
        public struct PlayerVariation
        {
            public PlayerType playerVariationType;
            public GameObject playerVariationPrefeb;
        }

        [System.Serializable]
        public struct DeployEnemies
        {
            public bool skeleton;
            public bool bringerOfDeeath;
            public bool HellHound;
        }
    }
}