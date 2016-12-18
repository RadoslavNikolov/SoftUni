#import random
#import matplotlib.pyplot as plt
#x = random.sample(range(1000), 100)
#plt.bar(range(0,100), x)
#plt.show()

#####===================================

#import matplotlib.pyplot as plt
#import numpy as np

#import plotly.plotly as py
#import plotly.tools as tls
#tls.set_credentials_file(username='rado_niko', api_key='UoGw7OLhvV2Ffjk8rMGJ')

#gaussian_numbers = np.random.randn(1000)
#print(gaussian_numbers)
#plt.hist(gaussian_numbers)
#plt.title("Gaussian Histogram")
#plt.xlabel("Value")
#plt.ylabel("Frequency")
#plt.show()

#fig = plt.gcf()

#plot_url = py.plot_mpl(fig, filename='mpl-basic-histogram')


####===================================
#def getInput():
#	r = float(input('Enter the radius:'))
#	return r

#import math
#r = getInput()
#area = 4 * math.pi * r ** 2
#volume = 4 / 3 * math.pi * r ** 3
#print("Area: " + str(round(area,3)))
#print("Volume: " + str(round(volume, 3)))

####===================================

#def histogram(cols):
#	for col in cols:
#		line = ""
#		for index in range(col):
#			line += "*"
#		print(line)


#histogram([4,3,8,10,0,2])

###===================================


#from matplotlib import rc
#rc('font',**{'family':'sans-serif','sans-serif':['Helvetica']})
#rc('text', usetex=True)

#import numpy as np
#import matplotlib.pyplot as plt

#t = np.arange(0.0, 1.0 + 0.01, 0.01)
#s = np.cos(4 * np.pi * t) + 2

#plt.rc('text', usetex=True)
#plt.rc('font', family='serif')
#plt.plot(t, s)

#plt.xlabel(r'\textbf{time} (s)')
#plt.ylabel(r'\textit{voltage} (mV)',fontsize=16)
#plt.title(r"\TeX\ is Number "
#          r"$\displaystyle\sum_{n=1}^\infty\frac{-e^{i\pi}}{2^n}$!",
#          fontsize=16, color='gray')
## Make room for the ridiculously large title.
#plt.subplots_adjust(top=0.8)

##plt.savefig('tex_demo')
#plt.show()


import matplotlib.pyplot as plt
import numpy as np
import math

x = np.arange(-6 * math.pi,6*math.pi,0.001)

y1 = 0.5 * np.sin(x)
y2 = np.sin(x)
y3 = 2 * np.sin(x)

y11 = np.sin(0.5 * x)
y12 = np.sin(x)
y13 = np.sin(2 * x)

plt.figure(1)
plt.axhline(0, linestyle = "--", color = "black")
plt.axvline(0, linestyle = "--", color = "black")
plt.ylim(-2,2)
plt.xlim(-2 * math.pi, 2 * math.pi)
plt.plot(x,y1, label='$y = 0.5\sin{(x)}$')
plt.plot(x,y2, label='$y = \sin{(x)}$')
plt.plot(x,y3, label='$y = 2\sin{(x)}$')

plt.title("Exploring the parameter of $y=a\sin{(bx)}$")
plt.legend(loc = 'best')


plt.figure(2)
plt.axhline(0, linestyle = "--", color = "black")
plt.axvline(0, linestyle = "--", color = "black")
plt.xlim(-2 * math.pi, 2 * math.pi)
plt.ylim(-2,2)
plt.plot(x,y11, label='$y = \sin{(0.5x)}$')
plt.plot(x,y12, label='$y = \sin{(x)}$')
plt.plot(x,y13, label='$y = \sin{(2x)}$')

plt.title("Exploring the parameter of $y=a\sin{(bx)}$")
plt.legend(loc = 'best')

plt.show()

