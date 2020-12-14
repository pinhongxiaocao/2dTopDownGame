using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Consts 
{
    public class Tags 
    {
        public static string Player = "Player";
    }

    /// <summary>
    /// 事件名字
    /// </summary>
    public class EventName 
    {
        public static string PlayerMove = "PlayerMove";
        public static string PlayerIdle = "PlayerIdle";

        public static string EnemyMove = "EnemyMove";
        public static string EnemyIdle = "EnemyIdle";
    }

    /// <summary>
    /// 动画层的一些参数
    /// </summary>
    public class AnimParams 
    {
        public static string isMoving = "isMoving";
    }
}
