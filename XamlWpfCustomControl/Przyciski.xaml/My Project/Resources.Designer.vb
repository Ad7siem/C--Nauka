﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ten kod został wygenerowany przez narzędzie.
'     Wersja środowiska uruchomieniowego: $clrversion$
'
'     Modyfikacje tego pliku mogą spowodować niewłaściwe zachowanie i zostaną utracone
'     w przypadku ponownego wygenerowania kodu.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My.Resources

    'Ta klasa została automatycznie wygenerowana za pomocą klasy StronglyTypedResourceBuilder
    'przez narzędzie, takie jak ResGen lub Visual Studio.
    'Aby dodać lub usunąć składową, edytuj plik ResX, a następnie ponownie uruchom narzędzie ResGen
    'z opcją /str lub ponownie skompiluj projekt programu VS.
    '''<summary>
    '''  Silnie typizowana klasa zasobów do wyszukiwania zlokalizowanych ciągów itd.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(), _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()> _
    Friend Module Resources

        Private resourceMan As Global.System.Resources.ResourceManager

        Private resourceCulture As Global.System.Globalization.CultureInfo

        '''<summary>
        '''  Zwraca buforowane wystąpienie składnika ResourceManager używane przez tę klasę.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("$safeprojectname$.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property

        '''<summary>
        '''  Przesłania właściwość CurrentUICulture bieżącego wątku dla wszystkich
        '''  przypadków przeszukiwania zasobów za pomocą tej silnie typizowanej klasy zasobów.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set(ByVal value As Global.System.Globalization.CultureInfo)
                resourceCulture = value
            End Set
        End Property
    End Module
End Namespace