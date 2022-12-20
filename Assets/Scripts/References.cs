using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class References
{
    // It will set to actual player when the game starts
    public static PlayerBehaviour thePlayer;
    public static CanvasBehaviour canvas;
    public static List<EnemySpawner> spawners = new List<EnemySpawner>();
    public static List<EnemyBehaviour> allEnemies = new List<EnemyBehaviour>();
    public static List<Useable> usables = new List<Useable>();
    public static List<Plinth> plinths = new List<Plinth>();
    public static ScreenShake screenShake;
    public static LevelManager levelManager;
    public static float maxDistanceInALevel = 1000;
    public static AlarmManager alarmManager;

    public static List<NavPoint> navPoints = new List<NavPoint>();
    // We could do also: LayerMask.GetMask("walls", "enemies" ...); 
    public static LayerMask wallsLayer = LayerMask.GetMask("Walls"); 
    public static LayerMask enemiesLayer = LayerMask.GetMask("Enemies"); 

}
