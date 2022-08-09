import os
import sys
from pathlib import Path 

path: str = os.path.dirname(os.path.abspath(__file__))
name: str = sys.argv[1]

os.chdir(f"{path}/MagicNight")
os.system(f"dotnet ef migrations add {name} --context DatabaseContext")
os.system(f"dotnet ef migrations add {name} --context CardsContext")
os.system(f"dotnet ef database update --context DatabaseContext")
os.system(f"dotnet ef database update --context CardsContext")