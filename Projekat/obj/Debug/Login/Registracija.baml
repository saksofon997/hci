   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Projekat.LoginProjekat.Login  5   	   !    Projekat.Login.Registracija   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Projekat.Login     5   	     � Title$  Registracija��5   	   $	��200��6   $	��400��6+   $��Center=�67   $��Center=�6T    � Icon$1 +pack://application:,,,/Resources/ititle.png��6o    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      �  � RowDefinitions 5   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6$   $��Ime: ��61   $��Center=�6>   $��Center=�6Y   $��14(�6v   �� 5   
   $��0��6   $��1��6$   $��	Lozinka: ��61   $��Center=�6B   $��Center=�6]   $��14(�6z   �� 5   
   -   5         ��Name$ 	TBUserNew��5      $��1��6%   $��0��65   $��25��6B   $	��150��6N   $��Center=�6Z   G� 5   
   -   5         G�Name$ 	TBPassNew��5   '    G� PasswordChar$ *��6   $��1��6:   $��1��6J   $��25��6W   $	��150��6c   $��Center=�6o   	 G� 	MaxLength$	 12��6�   �� 5    
   -   5        
 ��Name$
 BTAdd��5       $��2��6    $��0��60   $��2��6=   $��Center=�6N   $��14(�6i   $��Registracija��6w   $	��100��6�   $��25��6�   6�   5!      5"      