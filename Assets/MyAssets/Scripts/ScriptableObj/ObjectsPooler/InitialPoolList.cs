using UnityEngine;

namespace GenShootUnity.ScriptableObj.ObjectsPooler
{
    [CreateAssetMenu(fileName = "InitialPoolListSO", menuName = "ScriptableObject/ObjectPooler/InitialListSO", order = 1)]
    class InitialPoolList : ScriptableObject
    {
        public GameObject[] prefabs;
    }
}
