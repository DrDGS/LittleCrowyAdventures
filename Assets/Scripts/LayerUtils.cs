using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class LayerUtils
    {
        public const string PlayerLayerName = "Player";
        public const string EnemyLayerName = "Enemy";
        public const string PlayerHitLayerName = "PlayerHit";
        public const string EnemyHitLayerName = "EnemyHit";

        public static readonly int PlayerHitLayer = LayerMask.NameToLayer(PlayerHitLayerName);
        public static readonly int EnemyHitLayer = LayerMask.NameToLayer(EnemyHitLayerName);

        public static readonly int PlayerMask = LayerMask.GetMask(PlayerLayerName);
        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName);

        public static bool isPlayerHitbox(GameObject other) => other.layer == PlayerHitLayer;
        public static bool isEnemyHitbox(GameObject other) => other.layer == EnemyHitLayer;
    }
}
