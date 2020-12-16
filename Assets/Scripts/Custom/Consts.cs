using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Consts 
{
    /// <summary>
    /// 一些可破坏物品的名字
    /// </summary>
    public class BreakableName 
    {
        public static string Box = "Breakable/Box/Box";
        public static string BrokenPiece = "Breakable/Box/BrokenPiece";
    }


    /// <summary>
    /// 子弹名字
    /// </summary>
    public class BulletGame 
    {
        public static string Bullet_0 = "Bullets/Bullet_0";
        public static string Enemy_Bullet_0 = "Bullets/Enemy_Bullet_0";
    }

    /// <summary>
    /// 管理粒子效果
    /// </summary>
    public class ParticleName 
    {
        public static string Bullet_Impact_Effect = "Effect/Bullet_Impact_Effect";
        public static string Enemy_Hurted_Effect = "Effect/Enemy_Hurted_Effect";
    }


    /// <summary>
    /// 管理标签名字
    /// </summary>
    public class Tags 
    {
        public static string Player = "Player";
        public static string Enemy = "Enemy";
    }

    /// <summary>
    /// 事件名字
    /// </summary>
    public class EventName 
    {
        public static string PlayerMove = "PlayerMove";
        public static string PlayerIdle = "PlayerIdle";
        public static string PlayerDash = "PlayerDash";


        public static string PlayerHealth = "PlayerHealth";

        public static string EnemyMove = "EnemyMove";
        public static string EnemyIdle = "EnemyIdle";
        public static string EnemyAttack = "EnemyAttack";// 一个二维向量参数


    }

    /// <summary>
    /// 动画层的一些参数
    /// </summary>
    public class AnimParams 
    {
        public static string isMoving = "isMoving";//bool
        public static string dash = "dash";//trigger
    }
}
