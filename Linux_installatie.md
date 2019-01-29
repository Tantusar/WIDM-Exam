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
* Installeer zenity
```
sudo apt install zenity
```
* In Winetricks, ga naar "Install an application", dan "Cancel" en vervolgens "Install a Windows DLL or component" en installeer ie8, wmp9, dotnet40
* Klik daarna "Run winecfg" en schakel "Allow the window manager to control the windows" uit (onder Graphics).
* Download de .zip-versie van WIDM Exam en pak deze in een map uit. Start vervolgens WIDM Exam.exe met de Wine Windows Program Loader
* Selecteer het thema WIDM2016 onder Opmaak

Een paar kleine dingen:
* Mocht tijdens de test de taakbalk te zien zijn, open dan winecfg en stel een virtual desktop in.
* In Winetricks is het ook mogelijk extra lettertypen te installeren. Voor het standaardthema is het lettertype Lucida nodig.
