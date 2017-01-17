import numpy as np
import itertools as it
import random
from matplotlib import pyplot as plt


import numpy as np
import matplotlib.pyplot as plt

from scipy.stats import norm

x = np.linspace(-5,5,100)

s = [0.5,1,2] 
m = 1
c = ['b','r','y']

for sig,color in zip(s, c): 
	pdf= norm.pdf(x,m,sig)
	plt.plot(x,pdf, color, linewidth=2)

plt.xlim(-5, 5)
plt.ylim(0,0.6)
plt.legend(['mu = -1', 'mu = 0', 'mu = 1', 'sigma=1'], loc='best')
plt.title('Normal distribution')
plt.show()






ax = plt.figure().add_subplot(1,1,1)
x = np.arange(-5, 5, 0.01)


s = np.sqrt([0.2, 1, 5, 0.5])
m = [0, 0, 0, -2] 
c = ['b','r','y','g']

for mu, sig, color in zip(s, m, c): 
    gauss = make_gauss(1, sig, mu)(x)
    ax.plot(x, gauss, color, linewidth=2)

plt.xlim(-5, 5)
plt.ylim(0, 1)
plt.legend(['0.2', '1.0', '5.0', '0.5'], loc='best')
plt.show()



#n = [0.2,0.5,0.8]
#p = 30
#for i in range(0, len(n)):
#	plot_Binomial_Distribution(n[i], p)

#plt.title('Density plot for samples drawn from negative binomial n=%s, p=%s.\nTrue pmf in red' % (n, p))
#plt.ylabel('Probability p(x)')
#plt.xlabel('x')
#plt.show()

#def get_combinations(numbers, k):
#  return it.combinations(numbers, k)

#def print_salad_recipes(fruits):
#    for i in range(2,len(fruits)+1):
#        recipies = get_combinations(fruits,i)
#        for rec in recipies:
#            print(rec)

#fruits = ["apple", "grapes", "banana", "kiwi", "orange", "apricot", "cherry",
#"blueberry", "strawberry"]
#print_salad_recipes(fruits)



#print(it.permutations(nums))
## Random uniform Numbers
#def generate_random_numbers(n):
#  return np.random.uniform(0, 5, n)

#for n in [10, 1000, 10000, 100000]:
#  plt.figure()
#  plt.hist(generate_random_numbers(n))
#  plt.legend([r"$p(x)=\frac{1}{b-a}$"], loc=4)
#  plt.show()


#  # Coin Toss
#def toss_fair_coin():
#    toss = np.random.random()
#    return 0 if toss <= 0.5 else 1
#def toss_unfair_coin():
#  pass

#tosses = 10000

#result = []
#for i in range(tosses):
#    result.append(toss_fair_coin())

#bins = 2
#plt.hist(result, bins)
#plt.title("Coin Toss")
#plt.xlabel("Toss")
#plt.ylabel("Frequency")
#plt.locator_params(nbins = 10)
#plt.show()
