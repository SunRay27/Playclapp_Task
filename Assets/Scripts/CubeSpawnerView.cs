using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawnerView : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelRoot;

    [SerializeField]
    private TMP_InputField _spawnDelayField, _cubeSpeedField, _maxTravelDistanceField;

    [SerializeField]
    private Button _showMenuButton;

    [SerializeField]
    private CubeView _cubePrefab;

    [SerializeField]
    private Transform _spawnPoint;

    private CubeSpawnerPresenter _presenter;

    private bool _isOpen = true;



    private void Start()
    {
        _presenter = new CubeSpawnerPresenter(this);

        _showMenuButton.onClick.AddListener(ChangeMenuState);
        _spawnDelayField.onValueChanged.AddListener(_presenter.RequestSpawnDelayChange);
        _cubeSpeedField.onValueChanged.AddListener(_presenter.RequestSpeedChange);
        _maxTravelDistanceField.onValueChanged.AddListener(_presenter.RequestMaxDistanceChange);
    }

    private void ChangeMenuState()
    {
        _isOpen = !_isOpen;
        _panelRoot.SetActive(_isOpen);
    }

    public void UpdateValues(float spawnDelay, float cubeSpeed, float maxTravelDistance)
    {
        _spawnDelayField.SetTextWithoutNotify(spawnDelay.ToString());
        _cubeSpeedField.SetTextWithoutNotify(cubeSpeed.ToString());
        _maxTravelDistanceField.SetTextWithoutNotify(maxTravelDistance.ToString());
    }

    private void Update()
    {
        _presenter.Update();
    }

    internal void SpawnCube(float speed, float maxDistance)
    {
        CubeView newCube = Instantiate(_cubePrefab, _spawnPoint.position, Quaternion.identity);
        newCube.BeginMove(speed, maxDistance);
    }
}
