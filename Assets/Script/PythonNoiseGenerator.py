import numpy as np
from PIL import Image

# Image size
width, height = 512, 512

# Generate random noise (grayscale)
noise = np.random.rand(height, width) * 255
noise = noise.astype(np.uint8)

# Convert to image
image = Image.fromarray(noise, mode='L')

# Save or show
image.save("noise_texture.png")
image.show()