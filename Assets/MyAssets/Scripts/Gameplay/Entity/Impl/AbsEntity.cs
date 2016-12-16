using System;

using UnityEngine;

using GenShootUnity.Core.Services.ObjectsPooler;
using GenShootUnity.Gameplay.Trajectories;
using GenShootUnity.ScriptableObj.Trajectories;

namespace GenShootUnity.Gameplay.Entity
{
    // Everything related to Game Logic is likely an entity
    abstract class AbsEntity : AbsExtMonoBehaviour, IMovableObject, IDamageableObject, IPoolableObject
    {

        // Movable Object Fields.
        [SerializeField]
        private Trajectory trajectory_ = null;
        private ITrajectoryHandler trajectoryHandler = null;
        [SerializeField]
        private float speed_ = 0;


        // IMovableObject
        public float Speed
        {
            get { return speed_; }
            set { speed_ = value; }
        }

        public Trajectory Trajectory
        {
            get { return trajectory_; }
            set { trajectory_ = value; }
        }

        public virtual void Move(Directions dir, float deltaT) // TODO: Player ship need to override this to ensure ship stay within camera FOV.
        {
            Vector3 moveVector = Vector3.zero;

            if ( (dir & Directions.UP) == Directions.UP) moveVector += Vector3.up;
            if ((dir & Directions.RIGHT) == Directions.RIGHT) moveVector += Vector3.right;
            if ((dir & Directions.DOWN) == Directions.DOWN) moveVector += Vector3.down;
            if ((dir & Directions.LEFT) == Directions.LEFT) moveVector += Vector3.left;

            if (moveVector != Vector3.zero)
            {
                moveVector = moveVector.normalized * Speed * deltaT;

                transform.position += moveVector;
            }
        }

        public void StepMove(float deltaT)
        {
            if (Trajectory != null)
                trajectoryHandler.Step(Speed, deltaT);
        }


        // Unity Methods
        protected virtual void OnEnable()
        {
            if (Trajectory != null)
            {
                trajectoryHandler = ServiceProvider.GameFactory.NewTrajectoryHandler();
                trajectoryHandler.Bind(transform, Trajectory);
            }
        }

        protected virtual void OnDisable()
        {
            if (Trajectory != null)
            {
                trajectoryHandler.Unbind();
                trajectoryHandler = null;
            }
        }

        protected virtual void Update()
        {
            if (Trajectory != null) StepMove(Time.deltaTime);
        }


        // Default Implementations.
        void IDamageableObject.TakeDamage(float damage)
        {
            throw new NotImplementedException();
        }

        void IDamageableObject.Explode()
        {
            throw new NotImplementedException();
        }

        void IPoolableObject.Pool()
        {
            throw new NotImplementedException();
        }

        public IObjectsPool ParentPool { get { throw new NotImplementedException(); } }
    }
}
