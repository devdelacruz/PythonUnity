from pathlib import Path
import numpy as np
from PIL import Image
import UnityEngine

# Settings
width, height = 5, 5
filename = "noise_10x10.png"

# Controls bit white and block cells
spawn_chance = 0.3  # 30% spawns white tiles the rest are black

# Find Unity directory root
start_dir = Path.cwd()

project_root = None
for parent in [start_dir] + list(start_dir.parents):
    if (parent / "Assets").exists():
        project_root = parent
        break

if project_root is None:
    raise RuntimeError("Unity project root not found (Assets folder missing)")

# Unity Directory root
target_dir = project_root / "Assets" / "Script" / "PythonNoiseGenerated"
target_dir.mkdir(parents=True, exist_ok=True)

full_path = target_dir / filename

print("Saving to:", full_path)

# Generate noise
noise = np.random.choice(
    [0, 255],
    size=(height, width),
    p=[1 - spawn_chance, spawn_chance]
).astype(np.uint8)

# Save
image = Image.fromarray(noise, mode="L")
image.save(full_path)

print("Saved successfully:", full_path.exists())
UnityEngine.Debug.Log("Python: Successful Noise generated")