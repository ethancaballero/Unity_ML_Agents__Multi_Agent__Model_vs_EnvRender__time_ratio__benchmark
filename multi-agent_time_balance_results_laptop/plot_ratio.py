import matplotlib.pyplot as plt

plt.plot([1,2,4,8,16,32,48,64,96,128,144,160,192,256,384,512,768,1024], [1.1468276833248143,1.3518629229448313,1.505403312505698,1.7406202404691347,2.036434116331328,2.2777700029365455,2.434167570016633,2.4814285486796415,2.4637818917089134,2.448553321589696,2.3506313780276864,2.1358888745129145,1.9988667938153606,1.749473373097308,1.428303512155518,1.1710365389597241,0.9214484613802173,0.7519391864893077], 'ro')
plt.axis([0, 1200, 0, 3])
plt.xlabel('num_agents')
plt.ylabel('model_fwd_step_time_avg / env_step_time_avg')
plt.show()