Public Class CustomControl1
    Inherits Control

    Shared Sub New()
        'To wywołanie metody OverrideMetadata informuje system, że ten element chce dostarczyć styl, który jest inny niż jego klasa bazowa.
        'Ten styl jest zdefiniowany w klasie Themes\Generic.xaml
        DefaultStyleKeyProperty.OverrideMetadata(GetType(CustomControl1), New FrameworkPropertyMetadata(GetType(CustomControl1)))
    End Sub

End Class
