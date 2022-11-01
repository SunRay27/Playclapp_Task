using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerModel
{
    private CubeSpawnerPresenter presenter;
    private float spawnDelay;
    private float speed;
    private float maxDistance;

    public float SpawnDelay
    {
        get => spawnDelay; set
        {
            if (value != spawnDelay)
            {
                spawnDelay = value;
                onModelChanged?.Invoke();
            }
        }
    }
    public float Speed
    {
        get => speed; set
        {
            if (value != speed)
            {
                speed = value;
                onModelChanged?.Invoke();
            }
        }
    }
    public float MaxDistance
    {
        get => maxDistance; set
        {
            if (value != maxDistance)
            {
                maxDistance = value;
                onModelChanged?.Invoke();
            }
        }
    }

    public event Action onModelChanged;

    public CubeSpawnerModel(CubeSpawnerPresenter presenter)
    {
        this.presenter = presenter;

        Speed = 1;
        SpawnDelay = 1;
        MaxDistance = 5;

        onModelChanged += () => { presenter.OnModelChanged(SpawnDelay, Speed, MaxDistance); };
        onModelChanged?.Invoke();
    }
}
