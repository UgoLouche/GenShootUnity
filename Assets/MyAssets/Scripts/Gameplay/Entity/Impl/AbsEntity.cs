using System;

using UnityEngine;

using GenShootUnity.Core.Services.ObjectsPooler;
using GenShootUnity.Gameplay.Trajectories;

namespace GenShootUnity.Gameplay.Entity
{
    // Everything related to Game Logic is likely an entity
    abstract class AbsEntity : AbsExtMonoBehaviour, IMovableObject, IDamageableObject, IPoolableObject
    {

        // Movable Object Fields.
        [SerializeField]
        private ITrajectory trajectory_ = null;
        [SerializeField]
        private float speed_ = 0;


        // IMovableObject
        public float Speed
        {
            get { return speed_; }
            set { speed_ = value; }
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
            if (trajectory_ != null)
                trajectory_.Step(Speed, deltaT);
        }


        // Unity Methods
        protected virtual void OnEnable()
        {
            if (trajectory_ != null)
            {
                try { trajectory_.Bind(transform); }
                catch (InvalidOperationException e) { Debug.Log(e.Message); trajectory_ = null; } // TODO : Do this properly and define your own exception for that case. Also Debug.Log().
            }
        }

        protected virtual void OnDisable()
        {
            if (trajectory_ != null)
            {
                trajectory_.Unbind();
            }
        }
    }
}
