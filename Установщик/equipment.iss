; ��� ����������
#define   Name       "iNet"
; ������ ����������
#define   Version    "0.0.1"
; �����-�����������
#define   Publisher  "Bogovinka"
; ���� ����� ������������
#define   URL        "https://inet74.ru"
; ��� ������������ ������
#define   ExeName    "Equipment.exe"

[Setup]

; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{F3E2EDB6-78E8-4539-9C8B-A78F059D8647}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=C:\Users\mafak\Desktop\SetupWPFteach\����������
OutputBaseFileName=Equipment


; ��������� ������
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "License_ENG.txt"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; LicenseFile: "License_RUS.txt"

[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; ����������� ����
Source: "C:\Users\mafak\Desktop\SetupWPFteach\Equipment_Accounting\Equipment_Accounting\bin\Debug\Equipment_Accounting.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "C:\Users\mafak\Desktop\SetupWPFteach\Equipment_Accounting\Equipment_Accounting\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

