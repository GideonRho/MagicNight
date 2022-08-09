import os
import sys
from pathlib import Path 

scriptPath: str = os.path.dirname(os.path.abspath(__file__))
rootPath: str = scriptPath

def update():
    os.system(f"git pull")

def clear():
    os.system(f"systemctl stop magicnight")

def build():
    os.chdir(f"{rootPath}")
    os.system("dotnet clean")
    os.system("dotnet build")

def service():
    os.system(f"cp {rootPath}/magicnight.service /etc/systemd/system/magicnight.service")
    os.system("systemctl daemon-reload")
    os.system(f"systemctl start magicnight")
    
clear()
update()
build()
service()
