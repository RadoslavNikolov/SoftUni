import numpy as np
import itertools as it
import random
from matplotlib import pyplot as plt



def get_combinations(numbers, k):
  return it.combinations(numbers, k)

def print_salad_recipes(fruits):
    for i in range(2,len(fruits)+1):
        recipies = get_combinations(fruits,i)
        for rec in recipies:
            print(rec)

fruits = ["apple", "grapes", "banana", "kiwi", "orange", "apricot", "cherry", "blueberry", "strawberry"]
print_salad_recipes(fruits)



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
