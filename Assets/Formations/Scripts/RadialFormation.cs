using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RadialFormation : FormationBase
{
    [SerializeField] private int amount = 10;
    [SerializeField] private float radius = 1;
    [SerializeField] private float radiusGrowthMultiplier;
    [SerializeField] private float rotations = 1;
    [SerializeField] private int rings = 1;
    [SerializeField] private float ringOffset = 1;
    [SerializeField] private float nthOffset;


    public override IEnumerable<Vector3> EvaluatePoints()
    {
        int amountPerRing = amount / rings;
        float ringOffsetLocal = 0f;
        for (int i = 0; i < rings; i++)
        {
            for (int j = 0; j < amountPerRing; j++)
            {
                float angle = j * Mathf.PI * (2 * rotations) / amountPerRing + (i % 2 != 0 ? nthOffset : 0);

                float radiusLocal = this.radius + ringOffsetLocal + j * radiusGrowthMultiplier;
                float x = Mathf.Cos(angle) * radiusLocal;
                float z = Mathf.Sin(angle) * radiusLocal;

                Vector3 pos = new Vector3(x, 0, z);

                pos += GetNoise(pos);

                pos *= Spread;

                yield return pos;
            }

            ringOffsetLocal += ringOffset;
        }
    }

    #region Event Methods

    private void OnEnable()
    {
        EventManager<object[]>.UpdatePriceUI += UpdatePriceUI;
        EventManager<object[]>.SpawnStickman += SpawnStickman;
    }

    private void OnDisable()
    {
        EventManager<object[]>.UpdatePriceUI += UpdatePriceUI;
        EventManager<object[]>.SpawnStickman -= SpawnStickman;
    }

    private void SpawnStickman(object[] obj)
    {
        DOTween.To(() => radius, x => radius = x, 5, 0.5f);
    }

    private void UpdatePriceUI(object[] obj)
    {
        amount = (int) obj[0];
        amount = amount switch
        {
            < 100 => 3,
            >= 100 and < 300 => 6,
            >= 300 and < 500 => 9,
            >= 500 and < 750 => 12,
            >= 750 and < 1000 => 15,
            >= 1000 => 20
        };
    }

    #endregion
}