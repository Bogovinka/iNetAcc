; Èìÿ ïðèëîæåíèÿ
#define   Name       "iNet"
; Âåðñèÿ ïðèëîæåíèÿ
#define   Version    "0.0.1"
; Ôèðìà-ðàçðàáîò÷èê
#define   Publisher  "Bogovinka"
; Ñàôò ôèðìû ðàçðàáîò÷èêà
#define   URL        "https://inet74.ru"
; Èìÿ èñïîëíÿåìîãî ìîäóëÿ
#define   ExeName    "Equipment.exe"

[Setup]

; Óíèêàëüíûé èäåíòèôèêàòîð ïðèëîæåíèÿ, 
;ñãåíåðèðîâàííûé ÷åðåç Tools -> Generate GUID
AppId={{F3E2EDB6-78E8-4539-9C8B-A78F059D8647}

; Ïðî÷àÿ èíôîðìàöèÿ, îòîáðàæàåìàÿ ïðè óñòàíîâêå
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; Ïóòü óñòàíîâêè ïî-óìîë÷àíèþ
DefaultDirName={pf}\{#Name}
; Èìÿ ãðóïïû â ìåíþ "Ïóñê"
DefaultGroupName={#Name}

; Êàòàëîã, êóäà áóäåò çàïèñàí ñîáðàííûé setup è èìÿ èñïîëíÿåìîãî ôàéëà
OutputDir=C:\Users\mafak\Desktop\iNetAcc\Установщик
OutputBaseFileName=Equipment


; Ïàðàìåòðû ñæàòèÿ
Compression=lzma
SolidCompression=yes

[Tasks]
; Ñîçäàíèå èêîíêè íà ðàáî÷åì ñòîëå
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; Èñïîëíÿåìûé ôàéë
Source: "C:\Users\mafak\Desktop\iNetAcc\Equipment_Accounting\Equipment_Accounting\bin\Debug\Equipment_Accounting.exe"; DestDir: "{app}"; Flags: ignoreversion

; Ïðèëàãàþùèåñÿ ðåñóðñû
Source: "C:\Users\mafak\Desktop\iNetAcc\Equipment_Accounting\Equipment_Accounting\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

