//using UnityEngine;
//using System.Collections.Generic;

//public class Trajectory : MonoBehaviour
//{
//	public bool loop;
//	public List<Vector4> steps; //Those are relative move: i.e. deltas !
//	//x -> distance to move
//	//y -> orientation change
//	//z -> scale change
//	//w -> step time

//	public Trajectory(bool loop)
//	{
//		this.loop = loop;
//		steps = new List<Vector4> ();
//	}

//	public void Add(Vector4 elem)
//	{
//		steps.Add (elem);
//	}

//	public int GetSize()
//	{
//		return steps.Count;
//	}

//	public Vector4 Get(int i) //Handles Looping trajectories and overflow ! Yay
//	{
//		if (i < steps.Count)
//			return steps [i];
//		else if (!loop)
//			return steps [steps.Count - 1]; //Repeat ad infinitum the last move
//		else
//			return steps [i % steps.Count];
//	}

//	public void concat(Trajectory trajectory) //Keep the loop and timestep of the original
//	{
//		foreach (Vector4 v in trajectory.steps) 
//		{
//			Add (v);
//		}
//	}
//}


////Add a bunch of static methods for primitive trajectories (straight, curve, etc).















