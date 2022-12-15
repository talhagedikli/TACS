using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class References
{
    // It will set to actual player when the game starts
    public static GameObject thePlayer;
    public static GameObject canvas;
    public static EnemySpawner spawner;
    public static ScreenShake screenShake;
    // We could do also: LayerMask.GetMask("walls", "enemies" ...); 
    public static LayerMask wallsLayer = LayerMask.GetMask("Walls"); 
    public static LayerMask enemiesLayer = LayerMask.GetMask("Enemies"); 

}
