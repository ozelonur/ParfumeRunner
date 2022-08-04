using System.Collections.Generic;
using System.Linq;
using _GAME_.Scripts.Enums;
using _GAME_.Scripts.Managers;
using _GAME_.Scripts.Operators;
using DG.Tweening;
using UnityEngine;

public class ExampleArmy : Operator
{
    public bool canForm;
    private bool _canComplete;
    private FormationBase _formation;

    public FormationBase Formation
    {
        get
        {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    [SerializeField] private StickmanOperator unitPrefab;
    [SerializeField] private float unitSpeed = 2;

    private readonly List<StickmanOperator> _spawnedUnits = new List<StickmanOperator>();
    private List<Vector3> _points = new List<Vector3>();
    private Transform _parent;

    private void Awake()
    {
        _parent = new GameObject("Unit Parent").transform;
        _canComplete = false;
    }

    private void Update()
    {
        if (!canForm)
        {
            return;
        }

        SetFormation();
    }

    private void SetFormation()
    {
        _points = Formation.EvaluatePoints().ToList();

        if (_points.Count > _spawnedUnits.Count)
        {
            var remainingPoints = _points.Skip(_spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if (_points.Count < _spawnedUnits.Count)
        {
            Kill(_spawnedUnits.Count - _points.Count);
        }

        for (int i = 0; i < _spawnedUnits.Count; i++)
        {
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position,
                transform.position + _points[i], unitSpeed * Time.deltaTime);

            _spawnedUnits[i].characterAnimateOperator.PlayAnimation(
                _spawnedUnits[i].transform.position != transform.position + _points[i]
                    ? AnimationType.Walk
                    : AnimationType.Idle);
        }

        float distance = Vector3.Distance(_spawnedUnits[0].transform.position,
            StickmanManager.Instance.finishStickman.transform.position);

        if (!(distance < 6)) return;
        if (_canComplete) return;
        _canComplete = true;
        PlayParticles();
        DOVirtual.DelayedCall(1f, () => { Announce(EventManager<object[]>.OnGameComplete, true); });
    }

    private void Spawn(IEnumerable<Vector3> points)
    {
        foreach (Vector3 pos in points)
        {
            StickmanOperator unit = Instantiate(unitPrefab, transform.position + pos, Quaternion.identity, _parent);
            _spawnedUnits.Add(unit);
        }
    }

    private void Kill(int num)
    {
        for (int i = 0; i < num; i++)
        {
            StickmanOperator unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }

    private void PlayParticles()
    {
        foreach (StickmanOperator unit in _spawnedUnits)
        {
            unit.PlayParticle();
        }
    }

    #region Event Methods

    private void OnEnable()
    {
        EventManager<object[]>.SpawnStickman += SpawnStickman;
    }

    private void OnDisable()
    {
        EventManager<object[]>.SpawnStickman -= SpawnStickman;
    }


    private void SpawnStickman(object[] obj)
    {
        canForm = true;
    }

    #endregion
}