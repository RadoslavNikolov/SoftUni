import numpy as np
import matplotlib.pyplot as plt
from matplotlib.transforms import Affine2D

def visualize_transfromation(matrix, plot_title):
    fig = plt.figure()
    plt.axis("equal")
    ax = fig.add_subplot(111)

    # Limits, Lables and Grid
    ax.set_xlim(-5,5)
    ax.set_ylim(-5,5)
    ax
    
