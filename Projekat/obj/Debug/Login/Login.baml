   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Projekat.LoginProjekat.Login  5   	       Projekat.Login.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Projekat.Login     5   	   -   5          � Title$  Login��5   	   $	��200��6   $	��400��6$   $��Center=�60   $��Center=�6M    � Icon$1 +pack://application:,,,/Resources/ititle.png��6h    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6   $��0��6$   $��Ime: ��61   $��Center=�6?   $��Center=�6Z   $��14(�6w   �� 5   
   $��0��6   $��1��6$   $��	Lozinka: ��61   $��Center=�6C   $��Center=�6^   $��14(�6{   �� 5   
   -   5         ��Name$ TBUser��5      $��1��6"   $��0��62   $	��150��6?   $��25��6K   $��Center=�6W   G� 5   
   -   5         G�Name$ TBPass��5   '    G� PasswordChar$ *��6   $��1��67   $��1��6G   $	��150��6T   $��25��6`   $��Center=�6l   	 G� 	MaxLength$	 12��6�   �� 5    
   -   5        
 ��Name$
 BTLogin��5       $��2��6"   $��0��62   $��2��6?   $��Center=�6P   $��Prijava��6k   $	��100��6~   $��14(�6�   $��25��6�   6�   �� 5"   
   -   5        $
 BTRegistracija��5"      $��1��6)   $��2��69   $��Center=�6F   $��Registracija��6a   $	��100��6y   $��14(�6�   $��25��6�   6�   5#      5$      