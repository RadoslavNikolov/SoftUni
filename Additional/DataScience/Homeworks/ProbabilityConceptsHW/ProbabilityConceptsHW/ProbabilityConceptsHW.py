import math
import numpy as np
from scipy import exp, log
from scipy.special import gammaln
from matplotlib import pyplot as plt

def prob_unique_overflow(N,r):
    # Causes overflow of the float
    prob = np.math.factorial(N) / ((np.math.pow(N, r)) * (np.math.factorial(N - r)))
    return prob
    #return prob
def prob_unique(N,r):
    # We can use logarithms to avoid overflow or underflow.
    prob = exp(gammaln(N + 1) - gammaln(N - r + 1) - r * log(N))
    return prob
    #return prob
def calc_birthday_probability(people):
    N = 365
    return prob_unique(N,people)

def calc_nonUnique_birthday_probability():
    for x in range(1, 366):
     uniqueProb = calc_birthday_probability(x)
     if (1 - uniqueProb) > 0.5:      
        return x

#people = 23
#uniqueProb = calc_birthday_probability(people)
#print("is close to 0.5", np.isclose(uniqueProb, 0.5, rtol=1e-05, atol=1e-02, equal_nan=False))
#print("the probability of no shared birthdays for  = ", uniqueProb)
#print("the probability of having at least two shared birthdays = ", (1 - calc_birthday_probability(people)))

people = calc_nonUnique_birthday_probability()
print("We need " + str(people) + " people  to have in a room, so that the probability of two people sharing a birthday is > 0.5")

x = np.linspace(1, 100, 100)
p = 1 - calc_birthday_probability(x)
p_approx = 1 - np.exp(-x ** 2 / 730)

plt.figure(figsize=(8, 5))
plt.step(x, p, "k", lw=2)
plt.plot(x, p_approx, "r", lw=1)
plt.vlines(people, 0, calc_birthday_probability(people), linestyles=u'dashed')
plt.hlines(calc_birthday_probability(23), 0, people, linestyles=u'dashed')
plt.text(people + 0.5,0.02,' ~23')
plt.locator_params(nbins = 10)
plt.xlabel("Number of people in a room")
plt.ylabel("Probability of a pair")
plt.xlim(0,100)
plt.ylim(0,1)
plt.grid(True)
plt.legend([r"Probability: $\frac{365!}{365^n (365 - n)!}$",
            r"Approximation: $1-e^\frac{-n^2}{2\cdot 365}$"], loc=4)
plt.show()
