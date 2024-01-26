 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance;

    public static T Instance
    {
        // get�����ڷ� public static �Ӽ��� ����
        get
        {
            // �ٸ� instance�� ������ Ȯ��
            if(instance == null)
            {
                // FindObjectOfType<T>()�� ������ Ÿ���� ù ��°�� �ε�� ������Ʈ�� �˻�
                instance = FindObjectOfType<T>();

                // �˻��� ������Ʈ�� ã�� �� ������ ���ο� ������Ʈ�� �����ϰ�,
                // �̸��� �ٲٰ�, �������� ���� ������Ʈ�� �߰��Ѵ�.
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
