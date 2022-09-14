using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EndlessRun.ObstacleSpawn
{
    public class RoadSpawn : MonoBehaviour
    {
        public List<GameObject> Roads;
        private float _offset = 30f;
        
        void Start()
        {
            if (Roads != null && Roads.Count > 0)
            {
                Roads = Roads.OrderBy(r => r.transform.position.z).ToList();
            }
        }

        public void MoveRoad()
        {
            GameObject movedRoad = Roads[0];
            Roads.Remove(movedRoad);
            float newZ = Roads[Roads.Count - 1].transform.position.z + _offset;
            movedRoad.transform.position = new Vector3(0, 0, newZ);
            Roads.Add(movedRoad);

        }
    }
}
