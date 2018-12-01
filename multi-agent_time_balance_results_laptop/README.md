# Unity ML-Agents Multi-Agent Time Balance results
- purpose is to measure/understand ratio of how much time is spent running ml model & how much time is spent running simulated environment
- I recorded the env_step_time_avg & model_fwd_step_time with number_of_agents varied at [1,2,4,8,16,32,48,64,96,128,144,160,192,256,384,512,768,1024].
- performed on my 2016 Macbook Pro "2.2 GHz Intel Core i7"+"Intel Iris Pro 1536 MB" Laptop
- plot_pics folder contains 3 plot pictures of metrics as number_of_agents is varied:
	-ratio_of_model_over_env which is equal to "model_fwd_step_time_avg / env_step_time_avg"
	-model_fwd_step_time which is model_fwd_step_time_avg
	-env_step_time which is env_step_time_avg
- On my Laptop, ratio is greater than 1.0 (what we want) when number_of_agents is between 1-600, with a peak ratio of 2.5 at 64 agents.
- The environment is N agents that each can move left, right, down, up, or none discretely & that each observe 2 continuous scalars representing agent's own XY position. Each agent is a red capsule in it's own cubicle. Look at 1024_agents_with_cubicle_for_each.png for pic of what environment looks like. 
- Model used is default non-recurrent non-convolutional model used by PPO from Unity ml-agents-0.3.0b repo: https://github.com/Unity-Technologies/ml-agents/blob/0.3.0b/python/unitytrainers/models.py#L10
- Each agent uses all the same weights as every other agent.

#Versions used
tensorflow_version==1.6.0-rc1 cpu float32
unity_version==Unity_2017.3.1f1_Personal_64_bit