using UnityEngine;


[CreateAssetMenu(menuName = "Meus scripts/Armas", fileName = "arma")]
    public class ScriptableGun: ScriptableObject
    {
        public Sprite imgArma;
        public float angulo;
        public float danoProjetil;
        public float veloProjetil;
    }
