import numpy as np
import pandas as pd
import scipy.stats
from matplotlib import pyplot as plt
from random import randint



x = np.random.uniform(0,50,20)

plt.hist(x, bins = 5)
plt.show()



#birth_data = pd.read_table("birth_rates.csv")
##plt.hist(birth_data["Birthrate"], bins = 15)
##plt.boxplot(birth_data["Birthrate"])
#plt.scatter(birth_data["Year"], birth_data["Birthrate"])
#plt.show()
#scipy.stats.pearsonr(birth_data["Year"], birth_data["Birthrate"])


#data_m = pd.read_table("snowfall.csv", header = None)
#plt.figure()
#plt.hist(data_m, bins = 20)
#plt.xlabel("Lenght [m]")
#plt.ylabel("# of guesses")
#plt.legend()
#plt.show()
