; Имя приложения
#define   Name       "iNet"
; Версия приложения
#define   Version    "0.0.1"
; Фирма-разработчик
#define   Publisher  "Bogovinka"
; Сафт фирмы разработчика
#define   URL        "https://inet74.ru"
; Имя исполняемого модуля
#define   ExeName    "Equipment.exe"

[Setup]

; Уникальный идентификатор приложения, 
;сгенерированный через Tools -> Generate GUID
AppId={{F3E2EDB6-78E8-4539-9C8B-A78F059D8647}

; Прочая информация, отображаемая при установке
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}
AppPublisherURL={#URL}
AppSupportURL={#URL}
AppUpdatesURL={#URL}

; Путь установки по-умолчанию
DefaultDirName={pf}\{#Name}
; Имя группы в меню "Пуск"
DefaultGroupName={#Name}

; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir=C:\Users\mafak\Desktop\SetupWPFteach\Установщик
OutputBaseFileName=Equipment


; Параметры сжатия
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; LicenseFile: "License_ENG.txt"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; LicenseFile: "License_RUS.txt"

[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]

; Исполняемый файл
Source: "C:\Users\mafak\Desktop\SetupWPFteach\Equipment_Accounting\Equipment_Accounting\bin\Debug\Equipment_Accounting.exe"; DestDir: "{app}"; Flags: ignoreversion

; Прилагающиеся ресурсы
Source: "C:\Users\mafak\Desktop\SetupWPFteach\Equipment_Accounting\Equipment_Accounting\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

