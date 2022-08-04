using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using UnityEditor.AI;

public class LevelGenarator : MonoBehaviour
{
    [SerializeField] private Transform[] _platform;
    [SerializeField] private Transform[] _platformWithNoRightDoor;

    [SerializeField] private Transform[] _spawnPointPlatform;
    [SerializeField] private Transform[] _spawnPointPlatformWithNoRightDoor;

    [SerializeField] private int[] _numSpawnPoint;
    [SerializeField] private int[] _numSpawnPointWithoutRightDoor;

    [SerializeField] private NavMeshSurface[] _surface;

    private void Awake()
    {
        GenerateNumberForSpawn();
        TransformPlatform();
    }

    private void GenerateNumberForSpawn()
    {
        for(int i = 0; i <= (_platform.Length - 1); i++)
        {
            _numSpawnPoint[i] = i;
        }

        for(int i = 0; i <= (_platformWithNoRightDoor.Length - 1); i++)
        {
            _numSpawnPointWithoutRightDoor[i] = i;
        }

        System.Random random = new System.Random();
        _numSpawnPoint = _numSpawnPoint.OrderBy(x => random.Next()).ToArray();
        _numSpawnPointWithoutRightDoor = _numSpawnPointWithoutRightDoor.OrderBy(x => random.Next()).ToArray();
    }

    private void TransformPlatform()
    {
        for(int i = 0; i <= (_platform.Length - 1); i++)
        {
            _platform[i].position = _spawnPointPlatform[_numSpawnPoint[i]].position;
        }

        for(int i = 0; i <= (_platformWithNoRightDoor.Length - 1); i++)
        {
            _platformWithNoRightDoor[i].position = _spawnPointPlatformWithNoRightDoor[_numSpawnPointWithoutRightDoor[i]].position;
        }
    }

    private void Start()
    {
        for(int i = 0; i <= (_surface.Length - 1); i++)
        {
            _surface[i].BuildNavMesh();
        }
    }
}
