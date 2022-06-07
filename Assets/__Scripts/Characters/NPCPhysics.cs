using System;
using UnityEngine;

namespace __Scripts.Characters
{
    public class NPCPhysics : MonoBehaviour
    {
    
        private Vector3 _bottomLeftEdge;
        private Vector3 _topRightEdge;


        private void Update()
        {
            // transform.position = new Vector3(
            //     Mathf.Clamp(transform.position.x, _bottomLeftEdge.x, _topRightEdge.x),
            //     Mathf.Clamp(transform.position.y, _bottomLeftEdge.y, _topRightEdge.y),
            //     Mathf.Clamp(transform.position.z, _bottomLeftEdge.z, _topRightEdge.z)
            // );
        }
        
        public void SetLimit(Vector3 bottomEdgeToSet, Vector3 topEdgeToSet)
        {
            _bottomLeftEdge = bottomEdgeToSet;
            _topRightEdge = topEdgeToSet;
        }
    }
}