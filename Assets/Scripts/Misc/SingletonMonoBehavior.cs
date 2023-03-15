using System;
using UnityEngine;

// PS: 类名大驼峰 ,变量名小驼峰

public abstract class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour {
    // 单例,私有变量
    private static T instance;

    // 公开类型返回私有的值
    public static T Instance => instance;

    // protected 可以通过 继承和 虚拟方式访问
    // 实例不存在是创建该实例, 否则销毁该gameObject 实现单例
    // this 获取到当前对象 强转为 T类型
    protected virtual void Awake() {
        if (instance == null) {
            instance = this as T;
        } else {
            Destroy(gameObject);
        }
    }
}