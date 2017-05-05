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

		// POolable Object fields
		private IObjectsPool parentPool_ = null;


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

		// IPoolable methods
		public IObjectsPool ParentPool { get { return parentPool_; } }

		public virtual void Notify_enterPool(IObjectsPool pool)
		{
			if (ParentPool == null)
				parentPool_ = pool;
		}

		public virtual void Notify_leavePool()
		{
			//Is there anything to do here ?	
		}

		public void Pool()
		{
			Pool_custom ();

			if (ParentPool == null) {
				ServiceProvider.ObjectPooler.PoolObject (this);
			} 
			else 
			{
				ParentPool.PoolObject (this);
			}
		}

		// Custom pool subroutine... For customization purpose. 
		// Reset transform by default.
		protected virtual void Pool_custom()
		{
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
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
        public void TakeDamage(float damage)
        {
            throw new NotImplementedException();
        }

        public void Explode()
        {
            throw new NotImplementedException();
        }
    }
}
