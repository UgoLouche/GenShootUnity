using UnityEngine;
using System.Collections;


/*Main Class for object in the game*/
/*Every object can move and be destroyed*/
public abstract class FlyingObject : MonoBehaviour, PoolableObject, DamageableObject
{
	public Trajectory trajectory;
	public float speed;

	public int healthPool;

	public GameObject explosion;

	/*Private Fields*/
	private int poolID = -1;

	private int currentHp;

	private bool isMoving = true; // Start/Stop the following of the trajectory
	
	//Deal with trajectories
	private int trajectoryStep = -1;
	private float remainingTime; //How much time left before the next step;
	private Vector4 currentStep;
	
	
	
	/*** METHODS ***/
	public int GetPoolID()
	{
		if (poolID == -1)
			ObjectPooler.RequestID (this.gameObject);
		
		return poolID;
	}
	
	public void SwitchMove()
	{
		isMoving = !isMoving;
	}

	public void SwitchMove(bool state)
	{
		isMoving = state;
	}

	public void SetSize(float size)
	{
		if (size > 0)
			Resize (size);
	}

	/*Return the number of Hp left*/
	public int ReduceHp(int damage)
	{
		if (damage < 0) 
			damage *= -1;

		if  ( (currentHp -= damage) < 0 )
		{
			currentHp = 0;
			Explode();
		}

		return currentHp;
	}

    public int GetHealth()
    {
        return currentHp;
    }

	public void Explode()
	{
		GameObject newExplosion;

		newExplosion = ObjectPooler.GetObject (explosion.name);
		newExplosion.transform.position = transform.position;
		newExplosion.transform.rotation = transform.rotation;

		OnExplode ();

		ObjectPooler.PoolObject (gameObject);
	}
	
	protected void Update() 									//It seems "better" to deal with trajectory here ...
	{
		if (isMoving && trajectory != null) 
			StepMove ();
	}

	protected void Reset()
	{
		if (transform.parent != null) 
		{
			gameObject.tag = transform.parent.tag;
		}

		currentHp = healthPool;
		trajectoryStep = -1;
	}

	protected virtual void OnExplode () //By default do nothing, not abstract because it is a hassle to force implementation in all subclasses
	{ }

	private void OnEnable()
	{
		Reset (); //Works for now, remember to call base.reset if you redefine OnEnable();
	}

	private void StepMove() //Handles the movement along Trajectories
	{
		float deltaStep;
		float deltaTime = Time.deltaTime * speed; //Check the maths, larger delta time means everything go slower for this object
		
		if (trajectoryStep == -1) //First Call
		{
			trajectoryStep = 0;
			currentStep = trajectory.Get(0);
			remainingTime = currentStep.w;
		}
		
		//Re-Check the math if needed
		do
		{
			if (deltaTime > remainingTime) //If we go past destination
			{
				deltaTime -= remainingTime; //Remember how many deltaTime is left after destination have been reached
				deltaStep = remainingTime;	//and take a step of size remainingTIme to reach the next stat
			}
			else 						//This is the simple case where we take a step of size deltaTime
			{
				remainingTime -= deltaTime;
				deltaStep = deltaTime;
				deltaTime = 0; //There is no deltaTime left after the move
			}
			
			//Update the moveVector
			//Recheck the math
			deltaStep /= currentStep.w; //normalize
			MoveRotateResize(currentStep.x * deltaStep, 
			                 currentStep.y * deltaStep,
			                 Mathf.Pow( currentStep.z, deltaStep)
			                 );
			
			if (deltaTime > 0)	//Go to next state
			{
				currentStep = trajectory.Get( ++trajectoryStep );
				remainingTime = currentStep.w;
			}
		}
		while ( deltaTime > 0); 		//Loop while there is some weightShift left
	}
	
	
	//Move by xAxis and yAxis
	private void MoveRotateResize(Vector3 vect)
	{
		MoveRotateResize (vect.x, vect.y, vect.z);
	}
	
	
	//Same without Vect4
	private void MoveRotateResize(float x, float z, float scale)
	{
		Move (x);
		Rotate (z);
		Resize (scale);
	}
	
	
	private void Move(float yAxis)
	{
		transform.position = transform.TransformPoint (0, yAxis, 0);
	}
	
	
	//Rotate by zAxis
	private void Rotate(float zAxis)
	{
		transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.eulerAngles.x,
		                                                    transform.rotation.eulerAngles.y,
		                                                    transform.rotation.eulerAngles.z + zAxis)
		                                       );
	}
	
	
	//Resize by factor "factor"
	private void Resize(float factor)
	{
		transform.localScale = transform.localScale * factor;
	}
}



