   M S B A M L   `   `   `  ���� V  RGrafika Komputerowa Projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Grafika_Komputerowa_ProjektGrafika_Komputerowa_Projekt  ,    &Grafika_Komputerowa_Projekt.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:Grafika_Komputerowa_Projekt       � Title$  
MainWindow��$
��1000��$
��1600��.���  � ColumnDefinitions �� $��9* ��� $��1* �.+�� $��0�� � RowDefinitions �� $��1* ��� $��9* �.+��� $��0��
��� �|�$��2q�
���   �._��  �� $��* ��� $
��Auto �.+�c� 
���   �$��Center=�.@�o� 
���   �.@��� -   $	��Pen��$��30(�
��� �|�
���   �$��0q�$��Center=�m� $��Shapes��$��30(�
��� �|�$��Center=�.@�m� -   $��	Rectangle��m� -   $��Triangle��m� -   $��Circle��m� -   $��Polygon��m� $
��Line��$��30(�
��� �|�$��Center=�.@�m� -   $��Add Line��m� -   $��	Edit Line���� -   $
��Path��$��30(�
��� �|�
���   �$��0q�$��Center=��� -	   $��Color��$��30(�
��� �|�
���   �$��0q�$��Center=�m� $��Image��$��30(�
��� �|�$��Center=�.@�m� -
   $��
Show Image��m� -   $��Show Image with filter 1��m� -   $��Show Image with filter 2��m� $��	Thickness��$��30(�
��� �|�$��Center=�.@�m� -   $��2��m� -   $��4��m� -   $��8��m� -   $��16��m� -   $��32���� -   $
��Undo��$��30(�
��� �|�
���   �$��0q�$��Center=���  �� Orientation$ 
Horizontal=�$��1��$��Right=�$��	20,0,20,0q�.+��� $��Opacity��$��30(�
��� �|�$��Center=�$��0,0,20,0q��� -   $��opacitySlider�� � Minimum$ 0Q� � Maximum$ 1Q�$	��200�� � Value$ 1Q�$��Center=��� $��1��
���   �$��10q�._��� 
��� �|�$��5q�._��� -   $��paintSurface������  �� Color$ White�� �� Opacity$ 0Q��� $��1��
��� �|�$��2q�
���   �._��� .+��� 
��� �|�$��0,0,0,2q�._��� -   $��	Add Layer��$��30(�
��� �|�
���   ��� -   $��layersPanel��