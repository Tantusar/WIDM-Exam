* Installeer wine
```
sudo dpkg --add-architecture i386
wget -nc https://dl.winehq.org/wine-builds/Release.key
sudo apt-key add Release.key
sudo apt-add-repository https://dl.winehq.org/wine-builds/ubuntu/
sudo apt update
sudo apt install wine-stable winehq-stable
```
* Installeer winetricks
```
sudo apt install winetricks
```
* _Installeer mono-vbnc_ (waarschijnlijk niet nodig)
```
sudo apt install mono-vbnc
```
* _Installeer zenity_ (waarschijnlijk niet nodig)
```
sudo apt install zenity
```
* In Winetricks, ga naar "Install an application", dan "Cancel" en vervolgens "Install a Windows DLL or component" en installeer IE8, WMP10, .NET 4.0
* Installeer ttf-mscorefonts-installer
```
sudo apt install ttf-mscorefonts-installer
```
* In Winetricks, ga naar "Install an application", dan "Cancel" en vervolgens "Run winecfg" en schakel "Allow the window manager to control the windows" uit (onder Graphics).
* Download de .zip-versie van WIDM Exam en pak deze in een map uit. Start vervolgens WIDM Exam.exe met de Wine Windows Program Loader
* Selecteer het thema WIDM2016 onder Opmaak

* Mocht je tijdens de test de taakbalk zien, open dan winecfg en stel een virtual desktop in.
