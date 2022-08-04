using _GAME_.Scripts.Managers;
using DG.Tweening;
using UnityEngine;

namespace _GAME_.Scripts.Operators
{
    public class StickmanOperator : Operator
    {
        #region Serialized Fields

        [SerializeField] public CharacterAnimateOperator characterAnimateOperator;
        [SerializeField] private ParticleSystem particle;

        #endregion

        #region Private Variables

        private int _colorCount;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            transform.LookAt(StickmanManager.Instance.finishStickman.transform);
        }

        #endregion

        #region Public Methods

        public void PlayParticle()
        {
            DOVirtual.DelayedCall(Random.Range(.1f, .5f), () => { particle.Play(); });
        }

        #endregion
    }
}