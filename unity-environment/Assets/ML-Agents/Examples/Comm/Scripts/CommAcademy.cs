using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class CommAcademy : Academy {

	public List<Vector3> Goal_Positions;
	public List<GameObject> pointers;

	public int numGoals;
	public int numAgents;

	public List<float>reset_positions;

	public override void InitializeAcademy()
    {
    	reset_positions.Add(-31f);
    	reset_positions.Add(-29f);
    	reset_positions.Add(-27f);
    	reset_positions.Add(-25f);
    	reset_positions.Add(-23f);
    	reset_positions.Add(-21f);
    	reset_positions.Add(-19f);
    	reset_positions.Add(-17f);
    	reset_positions.Add(-15f);
    	reset_positions.Add(-13f);
    	reset_positions.Add(-11f);
    	reset_positions.Add(-9f);
    	reset_positions.Add(-7f);
    	reset_positions.Add(-5f);
    	reset_positions.Add(-3f);
    	reset_positions.Add(-1f);
    	reset_positions.Add(1f);
    	reset_positions.Add(3f);
    	reset_positions.Add(5f);
    	reset_positions.Add(7f);
    	reset_positions.Add(9f);
    	reset_positions.Add(11f);
    	reset_positions.Add(13f);
    	reset_positions.Add(15f);
    	reset_positions.Add(17f);
    	reset_positions.Add(19f);
    	reset_positions.Add(21f);
    	reset_positions.Add(23f);
    	reset_positions.Add(25f);
    	reset_positions.Add(27f);
    	reset_positions.Add(29f);
    	reset_positions.Add(31f);
    }

	public void Reset_Goals ()
	{

	}

	public override void AcademyReset()
	{
		//Debug.Log(99);
		//Reset_Goals();
	}

	public override void AcademyStep()
	{

	}

}
