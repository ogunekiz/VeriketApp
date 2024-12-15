!include "MUI2.nsh"
!include "x64.nsh" ; 64-bit kontrolü için dahil edildi
!include "LogicLib.nsh" ; Koşul kontrolü için dahil edildi

!define APP_NAME "Veriket Application"
!define SERVICE_NAME "Veriket Application Test"
!define SERVICE_DESCRIPTION "Veriket Application Test Service"

; Türkçe dil tanımlanıyor
!insertmacro MUI_LANGUAGE "Turkish"

; Simge dosyası ekleniyor
Icon "./veriketapp_install.ico"

; Setup dosyasının çıkarılacağı konum belirtiliyor
OutFile "../SetupFile/VeriketAppSetup.exe"

; Admin yetkisi ile çalıştırılıyor
RequestExecutionLevel admin

Var INSTALL_DIR

; Programın Başlığı
!define MUI_ABORTWARNING ; Kullanıcı kurulumdan çıkmaya çalışırsa uyarı mesajı gösterir.

; Başlık çubuğunda program adı gösteriliyor
Caption "${APP_NAME}"

; Sayfa tanımlama
Page instfiles

Function .onInit
    ; İşletim sistemi 64-bit mi kontrol ediliyor
    ${If} ${RunningX64}
        StrCpy $INSTALL_DIR "$PROGRAMFILES64\VeriketApp" ; 64-bit için Program Files
    ${Else}
        StrCpy $INSTALL_DIR "$PROGRAMFILES\VeriketApp" ; 32-bit için Program Files
    ${EndIf}
    ; InstallDir değişkenine yükleme dizinini ata
    StrCpy $INSTDIR $INSTALL_DIR
FunctionEnd

Section "Install VeriketApp" SecInstall
    SetOutPath $INSTALL_DIR

    ; WinForms ve Service uygulamalarını hedef dizine kopyalama işlemi
    File "..\..\VeriketApp.WinForm\bin\Release\net8.0-windows\publish\win-x64\VeriketApp.WinForm.exe"
    File "..\..\VeriketApp.Service\bin\Release\net8.0\publish\win-x64\VeriketApp.Service.exe"
    File "..\..\VeriketApp.WinForm\icon\veriketapp_icon.ico"

    ; VeriketApp dizini oluşturuluyor
    CreateDirectory $INSTALL_DIR

    ; Windows servisi kuruluyor
    nsExec::ExecToStack 'powershell -Command "New-Service -Name \"${SERVICE_NAME}\" -Binary \"$INSTALL_DIR\VeriketApp.Service.exe\" -Description \"${SERVICE_DESCRIPTION}\" -StartupType Automatic"'

    ; Servis başlatılıyor
    nsExec::ExecToStack 'powershell -Command "Start-Service \"${SERVICE_NAME}\""'

    ; WinForms uygulaması için masaüstüne kısayol oluşturuluyor
    CreateShortCut "$DESKTOP\${APP_NAME}.lnk" "$INSTALL_DIR\VeriketApp.WinForm.exe" "" "$INSTALL_DIR\veriketapp_icon.ico"
  

SectionEnd
