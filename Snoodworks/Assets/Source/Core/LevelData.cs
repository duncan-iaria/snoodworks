using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels/Level Data")]
public class LevelData : ScriptableObject
{
  public string displayName;
  public string levelName;
  public LevelData defaultNextLevel;
  public List<LevelData> linkedLevels = new List<LevelData>();
}
