using System.Globalization;
using UnityEngine;

public class CubeSpawnerPresenter
{
    private CubeSpawnerModel model;
    private CubeSpawnerView view;


    private CultureInfo _cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
    private NumberStyles _numberStyle = NumberStyles.Number;

    private float t;
    private float lastSpawnTime;

    public CubeSpawnerPresenter(CubeSpawnerView cubeSpawnerView)
    {
        view = cubeSpawnerView;
        model = new CubeSpawnerModel(this);

        lastSpawnTime = Time.time;
    }

    public void RequestSpawnDelayChange(string newValue)
    {
        if (TryParseFloatTrimmed(newValue, out float spawnDelay))
            model.SpawnDelay = spawnDelay;
    }

    public void RequestSpeedChange(string newValue)
    {
        if (TryParseFloatTrimmed(newValue, out float speed))
            model.Speed = speed;
    }

    public void RequestMaxDistanceChange(string newValue)
    {
        if (TryParseFloatTrimmed(newValue, out float maxDistance))
            model.MaxDistance = maxDistance;
    }

    internal void OnModelChanged(float spawnDelay, float speed, float maxDistance)
    {
        view.UpdateValues(spawnDelay, speed, maxDistance);
    }

    private bool TryParseFloatTrimmed(string s, out float result)
    {
        s = s.Replace(',', '.');
        return float.TryParse(s, _numberStyle, _cultureInfo, out result);
    }


    internal void Update()
    {
        t = Time.time;
        if (t > lastSpawnTime + model.SpawnDelay)
        {
            view.SpawnCube(model.Speed, model.MaxDistance);
            lastSpawnTime = t;
        }
    }
}
