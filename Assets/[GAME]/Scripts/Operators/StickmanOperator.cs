using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Managers;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GAME_.Scripts.Operators
{
    public class StickmanOperator : Operator
    {
        #region Serialized Fields

        [SerializeField] private SkinnedMeshRenderer meshRenderer;
        [SerializeField] private CharacterAnimateOperator characterAnimateOperator;

        #endregion

        #region Private Variables

        private Transform _target;

        private int _colorCount;
        private bool _canLookAt;

        #endregion

        #region MonoBehaviour Methods

        private void Start()
        {
            _colorCount = StickmanManager.Instance.stickmanMaterials.Length;
            _canLookAt = false;
            GiveColor();
        }

        private void Update()
        {
            if (!_canLookAt)
            {
                return;
            }

            transform.LookAt(_target.position);
        }

        #endregion

        #region Private Methods

        private void GiveColor()
        {
            meshRenderer.material = StickmanManager.Instance.stickmanMaterials[Random.Range(0, _colorCount)];
        }

        #endregion

        #region Public Methods

        public void StartMoving(Transform target)
        {
            _target = target;

            Vector3 offset = Random.insideUnitSphere * Random.Range(7.5f, 15f);

            transform.DOMove(target.position + new Vector3(offset.x, 0, offset.z), 5f)
                .OnStart(() => { characterAnimateOperator.PlayAnimation(AnimationType.Walk); })
                .OnComplete(() =>
                {
                    characterAnimateOperator.PlayAnimation(AnimationType.Dance);
                    StickmanManager.Instance.finishStickman.characterAnimateOperator.PlayAnimation(AnimationType.Kiss);
                })
                .SetDelay(Random.Range(0f, .5f))
                .SetEase(Ease.Linear)
                .SetLink(gameObject);

            _canLookAt = true;
        }

        #endregion
    }
}