﻿using UnityEngine;
using System;
using UnityEngine.AI;
using Code.Level.Way;
using Code.Level.Way.Follower;

namespace Code.Human.Hero
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class HeroWayFollower : MonoBehaviour, IWayFollower
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _destinationDistance;

        private Vector3 _lookAtPoint;

        public event Action PointReached;

        private void Update()
        {
            transform.LookAt(_lookAtPoint);

            if (_navMeshAgent.hasPath &&
                _navMeshAgent.remainingDistance < _destinationDistance)
            {
                _navMeshAgent.ResetPath();
                PointReached?.Invoke();
            }
        }

        public void SetPoint(IWayPoint wayPoint)
        {
            _navMeshAgent.SetDestination(wayPoint.Position);
        }

        public void SetLookTarget(Vector3 point)
        {
            _lookAtPoint = point;
        }
    }
}