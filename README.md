# 🚀 Apps Service

It is a Service Runner , Service Runner is a Windows service that automatically runs your console applications (`.exe` and `.bat` files) at system startup.  
It uses a simple SQLite database to store the paths of your applications, so you don’t need to configure each one as a separate service.

---

## ✨ Features
- Run multiple `.exe` and `.bat` files automatically at startup
- Uses SQLite for simple path storage
- One service to rule them all – no need to create multiple Windows services
- Easy to use: just add paths and let the service do the rest

---

## 📥 Installation
1. Download the latest release from the [Releases](../../releases) page.
2. Extract the file from the `.zip` archive.
3. First run the **Directory.exe** and Enter the number of apps you want to add (enter 0 if you want to add a single application) <img width="353" height="34" alt="image" src="https://github.com/user-attachments/assets/ba066119-3338-4243-a5a5-a64ad8ee9df5" />
4. After that Enter the locations of your apps (for example `C:\MinecraftServer\Start.bat`)<img width="559" height="59" alt="image" src="https://github.com/user-attachments/assets/7767fac3-2460-41d7-b333-37674d27d41f" />
5. Open the cmd (run as administrator).
6. Run the following command: `sc create ServiceRunner binPath= "YOUR SERVICE LOCATION\AppsService.exe" start= auto`.
7. Then, start the service with: `sc start ServiceRunner`.

## ⚠️ Warning:
**If your program is located in a user account directory, you must follow the instructions below.** 
1. Press `Windows + R`
2. Enter `services.msc` and press Enter
3. Find your service's name
4. Right-click on it and select Properties
5. Go to the "Log On" Tab
6. Choose "This Account" and Enter your Username and Password
7. Click Apply , then OK
---
## 🛠️ Usage
- Use the **Directory.exe** program to add `.exe` or `.bat` file paths into the database.  
- The **AppsService.exe** will automatically detect and run them at system startup.  
⚠️ Note: Currently, the service only starts console programs.

---

## 📄 License
This project is open-source and licensed under the [MIT License](LICENSE).

---
## 📘 Documentation
For more details and updates, please check the [Releases](../../releases) page or see the source code.  
