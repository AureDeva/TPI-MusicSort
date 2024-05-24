; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "MusicSort"
#define MyAppVersion "1.5"
#define MyAppPublisher "Aur�lien D�vaud, ETML"
#define MyAppExeName "MusicSort.exe"
#define InputDirectory "C:\Users\pp50oip\Desktop\Projects\TPI-MusicSort\02-ContenuProjet\MusicSort\MusicSort\bin\Release"
#define OutputDirectory "C:\Users\pp50oip\Desktop\Projects\TPI-MusicSort\02-ContenuProjet\Installeur"
#define ScriptDirectory "C:\Users\pp50oip\Desktop\Projects\TPI-MusicSort\02-ContenuProjet\Installeur"
#define Icon "C:\Users\pp50oip\Desktop\Projects\TPI-MusicSort\02-ContenuProjet\MusicSort\MusicSort\Images\music-file.ico"
#define FrameworkInstaller "ndp472-devpack-fra.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D6490830-A0FE-452B-80A6-A80D0797B706}
AppName={#MyAppName}
AppVersion={#MyAppVersion}

;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes

; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputDir={#OutputDirectory}
OutputBaseFilename=MusicSort-Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

SetupIconFile={#Icon}

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#InputDirectory}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#ScriptDirectory}\{#FrameworkInstaller}"; DestDir: "{app}"; Flags: deleteafterinstall
Source: "{#InputDirectory}\AxInterop.WMPLib.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\Interop.WMPLib.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\libmp3lame.32.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\libmp3lame.64.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\Microsoft.Win32.Registry.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\Microsoft.Win32.Registry.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\MusicSort.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\MusicSort.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Asio.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Asio.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Lame.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Lame.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Midi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Midi.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Wasapi.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.Wasapi.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.WinForms.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.WinMM.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.WinMM.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\NAudio.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\System.Security.AccessControl.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\System.Security.AccessControl.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\System.Security.Principal.Windows.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#InputDirectory}\System.Security.Principal.Windows.xml"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#FrameworkInstaller}"; Parameters: "/passive /norestart"; Check: NeedsDotNetFramework 
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
{ Function to check if .NET Framework 4.7.2 is installed }
function NeedsDotNetFramework: Boolean;
var
  InstallKey: string;
  ReleaseValue: Cardinal;
begin
  InstallKey := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full';
  if RegQueryDWordValue(HKLM, InstallKey, 'Release', ReleaseValue) then
  begin
    Result := ReleaseValue < 461808;
  end
  else
  begin
    Result := True;
  end;
end;

