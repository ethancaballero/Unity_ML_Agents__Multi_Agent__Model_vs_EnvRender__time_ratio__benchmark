using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommAgent : Agent
{

	/*
	public int position;
	public int smallGoalPosition;
	public int largeGoalPosition;
	public GameObject largeGoal;
	public GameObject smallGoal;
	public int minPosition;
	public int maxPosition;
	*/

	public List<Camera> AllCameras;

	public Vector3 m_MoveDirs = Vector3.zero;
	//Vector3 m_MoveDirs = Vector3.zero;

	public CharacterController m_CharacterController;
	//public CharacterController m_CharacterController = gameObject.GetComponent<CharacterController>();	
	//m_CharacterController = gameObject.GetComponent<CharacterController>();

	/*
	public m_CharacterTargetRot;
	m_CharacterTargetRot = player.transform.localRotation;
	*/

	//public List<GameObject> pointers;
	public List<GameObject> Actors;

	private float speedMove = 10f;
    private float speedRot = 2f;



    //public List<Vector3> Goal_Positions;
	//public List<GameObject> pointers;

	//public int numGoals;
	//public int numAgents = 2;


	public List<float>reset_positions;

	CommAcademy academy;
	

    public override void InitializeAgent()
    {
    	academy = FindObjectOfType<CommAcademy>();
    	m_CharacterController = gameObject.GetComponent<CharacterController>();

    	/*
    	AllCameras.Add (GameObject.Find ("Main Camera").GetComponent<Camera> ());
		AllCameras.Add (GameObject.Find ("Agent1 Camera").GetComponent<Camera> ());
		AllCameras.Add (GameObject.Find ("Agent2 Camera").GetComponent<Camera> ());
		*/

		Actors.Add(gameObject);
		//Actors.Add(GameObject.Find ("Agent (2)"));

		AllCameras.Add (GameObject.Find ("Main Camera").GetComponent<Camera> ());
		/*
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
    	*/

    	//SoccerAcademy academy;
    }



	/*
	public List<Camera> collectObservations() {
		List<Camera> cameras = new List<Camera> ();
		cameras = AllCameras;
		return cameras;
	}
	*/

	
	public override void CollectObservations()
	{
		//state.Add(0);

		AddVectorObs(Actors[0].transform.position.x);
		AddVectorObs(Actors[0].transform.position.z);
		//AddVectorObs(Actors[1].transform.position.x);
		//AddVectorObs(Actors[1].transform.position.z);
		/*
		AddVectorObs(pointers[0].transform.position.x);
		AddVectorObs(pointers[0].transform.position.z);
		AddVectorObs(pointers[1].transform.position.x);
		AddVectorObs(pointers[1].transform.position.z);
		*/

		/*
		Debug.Log(state[0]);
		Debug.Log(state[1]);
		Debug.Log(state[2]);
		Debug.Log(state[3]);
		Debug.Log(state[4]);
		Debug.Log(state[5]);
		Debug.Log(state[6]);
		Debug.Log(state[7]);
		*/

		//return state;
	}

	public void DetectOverlap()
	{

	}

	public void DetectDistance()
	{

	}

	//public override void AgentAction(float[] act)
	public override void AgentAction(float[] vectorAction, string textAction)
	{

		//Debug.Log(act);

		/*
		Debug.Log(gameObject.name);
		if(gameObject.name == "Agent1")
		{

		}
		else if(gameObject.name == "Agent2")
		{

		}
		*/

		float x = 0f;
		float y = 0f;
		float z = 0f;

		/*
		if (action == 1){
			y = -1f;
		}else if (action == 2){
			y = 1f;
		} 
		*/
		//int action = Mathf.FloorToInt(act[0]);
		int action = Mathf.FloorToInt(vectorAction[0]);
		if (action == 1){
			z = -1f;
		}else if (action == 2){
			z = 1f;
		}
		if (action == 3){
			x = -1f;
		}else if (action == 4){
			x = 1f;
		}


		//DetectOverlap();
		//DetectDistance();
		
		
		//Debug.Log(gameObject.name);
		//Debug.Log(reward);
		

		//Debug.Log(rewards[0]);
		//Debug.Log(rewards[1]);

		// Rotation
		/*
		y *= speedRot;
        m_CharacterTargetRots[a_id] *= Quaternion.Euler (0f, y, 0f);
        players[a_id].transform.localRotation = m_CharacterTargetRots[a_id];
        */

        // From Here to end of Function is Movement
        Vector2 m_Input = new Vector2(x, z);

        // normalize input if it exceeds 1 in combined length:
        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        // always move along the camera forward as it is the direction that it being aimed at
        Vector3 desiredMove = gameObject.transform.forward*m_Input.y + gameObject.transform.right*m_Input.x;

        //Debug.Log(m_Input);

        Vector3 MoveDirTemp = m_MoveDirs;

        MoveDirTemp.x = desiredMove.x*speedMove;
        MoveDirTemp.z = desiredMove.z*speedMove;

        MoveDirTemp += Physics.gravity*Time.fixedDeltaTime;

        m_MoveDirs = MoveDirTemp;

        m_CharacterController.Move(m_MoveDirs*Time.fixedDeltaTime);

		/*
		float movement = act[0];
		int direction = 0;
		if (movement == 0) { direction = -1; }
		if (movement == 1) { direction = 1; }

		position += direction;
		if (position < minPosition) { position = minPosition; }
		if (position > maxPosition) { position = maxPosition; }

		gameObject.transform.position = new Vector3(position, 0f, 0f);

        reward -= 0.01f;

		if (position == smallGoalPosition)
		{
			done = true;
			reward = 0.1f;
		}

		if (position == largeGoalPosition)
		{
			done = true;
			reward = 1f;
		}
		*/
	}

	public override void AgentReset()
	{

		//Seteward = 0f;
		//agent.GetComponent<ReacherAgent>().SetReward(0f);

		gameObject.transform.rotation = new Quaternion (0f, 0f, 0f, 0f);
		gameObject.GetComponent<CommAgent>().SetReward(0f);
		Transform parent = gameObject.transform.parent.transform.parent.transform.parent;

		float z_col = 0f;
		string agentColumn = gameObject.transform.parent.name;

		if(agentColumn == "AgentColumn (1)")
		{
			z_col = academy.reset_positions[0];
		}
		else if(agentColumn == "AgentColumn (2)")
		{
			z_col = academy.reset_positions[1];
		}
		else if(agentColumn == "AgentColumn (3)")
		{
			z_col = academy.reset_positions[2];
		}
		else if(agentColumn == "AgentColumn (4)")
		{
			z_col = academy.reset_positions[3];
		}
		else if(agentColumn == "AgentColumn (5)")
		{
			z_col = academy.reset_positions[4];
		}
		else if(agentColumn == "AgentColumn (6)")
		{
			z_col = academy.reset_positions[5];
		}
		else if(agentColumn == "AgentColumn (7)")
		{
			z_col = academy.reset_positions[6];
		}
		else if(agentColumn == "AgentColumn (8)")
		{
			z_col = academy.reset_positions[7];
		}

		else if(agentColumn == "AgentColumn (9)")
		{
			z_col = academy.reset_positions[8];
		}
		else if(agentColumn == "AgentColumn (10)")
		{
			z_col = academy.reset_positions[9];
		}
		else if(agentColumn == "AgentColumn (11)")
		{
			z_col = academy.reset_positions[10];
		}
		else if(agentColumn == "AgentColumn (12)")
		{
			z_col = academy.reset_positions[11];
		}
		else if(agentColumn == "AgentColumn (13)")
		{
			z_col = academy.reset_positions[12];
		}
		else if(agentColumn == "AgentColumn (14)")
		{
			z_col = academy.reset_positions[13];
		}
		else if(agentColumn == "AgentColumn (15)")
		{
			z_col = academy.reset_positions[14];
		}
		else if(agentColumn == "AgentColumn (16)")
		{
			z_col = academy.reset_positions[15];
		}

		else if(agentColumn == "AgentColumn (17)")
		{
			z_col = academy.reset_positions[16];
		}
		else if(agentColumn == "AgentColumn (18)")
		{
			z_col = academy.reset_positions[17];
		}
		else if(agentColumn == "AgentColumn (19)")
		{
			z_col = academy.reset_positions[18];
		}
		else if(agentColumn == "AgentColumn (20)")
		{
			z_col = academy.reset_positions[19];
		}
		else if(agentColumn == "AgentColumn (21)")
		{
			z_col = academy.reset_positions[20];
		}
		else if(agentColumn == "AgentColumn (22)")
		{
			z_col = academy.reset_positions[21];
		}
		else if(agentColumn == "AgentColumn (23)")
		{
			z_col = academy.reset_positions[22];
		}
		else if(agentColumn == "AgentColumn (24)")
		{
			z_col = academy.reset_positions[23];
		}

		else if(agentColumn == "AgentColumn (25)")
		{
			z_col = academy.reset_positions[24];
		}
		else if(agentColumn == "AgentColumn (26)")
		{
			z_col = academy.reset_positions[25];
		}
		else if(agentColumn == "AgentColumn (27)")
		{
			z_col = academy.reset_positions[26];
		}
		else if(agentColumn == "AgentColumn (28)")
		{
			z_col = academy.reset_positions[27];
		}
		else if(agentColumn == "AgentColumn (29)")
		{
			z_col = academy.reset_positions[28];
		}
		else if(agentColumn == "AgentColumn (30)")
		{
			z_col = academy.reset_positions[29];
		}
		else if(agentColumn == "AgentColumn (31)")
		{
			z_col = academy.reset_positions[30];
		}
		else if(agentColumn == "AgentColumn (32)")
		{
			z_col = academy.reset_positions[31];
		}

		string gameObjectName = gameObject.name;

		if(gameObjectName == "Agent (1)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[0], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (2)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[1], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (3)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[2], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (4)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[3], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (5)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[4], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (6)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[5], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (7)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[6], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (8)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[7], 0f+parent.position.y, z_col));
		}

		else if(gameObjectName == "Agent (9)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[8], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (10)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[9], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (11)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[10], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (12)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[11], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (13)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[12], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (14)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[13], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (15)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[14], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (16)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[15], 0f+parent.position.y, z_col));
		}

		else if(gameObjectName == "Agent (17)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[16], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (18)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[17], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (19)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[18], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (20)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[19], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (21)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[20], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (22)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[21], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (23)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[22], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (24)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[23], 0f+parent.position.y, z_col));
		}

		else if(gameObjectName == "Agent (25)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[24], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (26)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[25], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (27)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[26], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (28)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[27], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (29)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[28], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (30)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[29], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (31)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[30], 0f+parent.position.y, z_col));
		}
		else if(gameObjectName == "Agent (32)")
		{
			gameObject.transform.position = (new Vector3 (academy.reset_positions[31], 0f+parent.position.y, z_col));
		}





	}

	public override void AgentOnDone()
	{

	}
}
