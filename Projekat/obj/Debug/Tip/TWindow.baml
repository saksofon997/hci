   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat.TipProjekat.Tip  5   	   9!clr-namespace:Projekat.ValidacijaProjekat.Validacija  5   	       Projekat.Tip.TWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Projekat.Tip     5   	   8
validacija!clr-namespace:Projekat.Validacija     5   	   -   5        $��TWindowN��5
   .     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$	 Tip��5
   	   $	��350��6   $	��600��6"    � Icon$1 +pack://application:,,,/Resources/ititle.png��6>   $��Center=�6q   $��Center=�6�    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5      � $��10, 10q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   $��Center=�6$   $��0��6?   $��Oznaka: ��6L   $��14(�6\   �� 5   
   $��0��6   $��Center=�6$   $��1��6?   $��Ime: ��6L   $��14(�6Y   �� 5    
   $��0��6   $��Center=�6$   $��2��6?   $��Opis: ��6L   $��14(�6Z   �� 5!   
   $��0��6   $��Center=�6$   $��3��6?   $��	Ikonica: ��6L   $��14(�6]   �� 5#   
   -   5         ��Name$ OznakaTB��5#      $��30��6$   $��10,5,150, 5q�63   $��1��6k   $��0��6{   $��14(�6�   .��6�   ��5$      �� 5%       �� Path$ novi.Oznaka�6   	 �� UpdateSourceTrigger$	 PropertyChanged=�6-   
 �� ValidationRules
 5&      (   "Projekat.Validacija.NameValidation  5'      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�64   5)      .��5*       =� ErrorTemplate 5+      �� 5,      .R�5-      �  5.      �� 5/       51      �� 52      �� 53      $
��Auto �6/   .+�56      ��  ��Name$ textBox��6Q   $��0��64   $��0��6D   6Q   �� 57      $��1��6$   $��0��64   
���  ����6A   �� *[0].ErrorContent+6c   58      59      .��5:   (   5;      �� 5<   
   -   5        $ ImeTB��5<      $��30��6!   $��10,5,150, 5q�60   $��1��6E   $��1��6U   $��14(�6b   .��6p   ��5=      �� 5>      $ novi.Ime�6   $	 PropertyChanged=�6*   
 5?        5@      $ RawProposedValue=�64   5B      .��5C       5D      �� 5E      .R�5F      �  5G      �� 5H       5J      �� 5K      �� 5L      $
��Auto �6/   .+�5O      �� $ textBox��6Q   $��0��64   $��0��6D   6Q   �� 5P      $��1��6$   $��0��64   
���  ����6A   �� *[0].ErrorContent+6c   5Q      5R      .��5S   (   5T      �� 5U   
   -   5        $ OpisTB��5U      $	��150��6"   $��10,5,150, 5q�62   $��1��6G   $��2��6W   $��14(�6d   �� 5W   
   -   5         ��Name$ Slika��5W      $
��Fill=�6   $��3��6.   $��1��6;   $��Right=�6K   $	��200��6g   �� 5Y   
   -   5        $��1��5Y      $��3��6!   $
��50,0q�6.   $	��100��6<   $��25��6H   $
��Left=�6T   $��14(�6o   $��Izaberi��6�   �� 5[   
   -   5         ��Name$ Button1��5[      $��Sačuvaj��6"   $��14(�64   $��1��6B   $��4��6R   $	��100��6_   $��25��6k   $��Center=�6w   6�   5\      5]      