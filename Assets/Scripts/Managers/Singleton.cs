 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance;

    public static T Instance
    {
        // get접근자로 public static 속성을 구현
        get
        {
            // 다른 instance가 없는지 확인
            if(instance == null)
            {
                // FindObjectOfType<T>()은 지정한 타입의 첫 번째로 로드된 오브젝트를 검색
                instance = FindObjectOfType<T>();

                // 검색한 오브젝트를 찾을 수 없으면 새로운 오브젝트를 생성하고,
                // 이름을 바꾸고, 지정되지 않은 컴포넌트를 추가한다.
                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }

            return instance;
        }
    }
    public virtual void Awake()
    {
        if(Instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
