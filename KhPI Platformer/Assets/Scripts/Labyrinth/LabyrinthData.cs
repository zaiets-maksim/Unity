using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth{
[CreateAssetMenu(fileName = "New LabyrinthData", menuName = "LabyrinthData", order = 0)]
public class LabyrinthData : ScriptableObject {
 [SerializeField] private string _labyrinth;
 public string Labyrinth { get { return _labyrinth;}}
 [SerializeField] private Vector2 _startPositionSquare;
 public Vector2 StartPositionSquare { get { return _startPositionSquare;}}
 [SerializeField] private Vector2 _endPositionSquare;
 public Vector2 EndPositionSquare { get { return _endPositionSquare;}}

 }
}